#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using VladislavTsurikov.ReflectionUtility.Runtime;

namespace VladislavTsurikov.CustomInspector.Editor.Core
{
    public abstract class InspectorFieldsDrawer<TDrawer>
        where TDrawer : FieldDrawer
    {
        private readonly List<TDrawer> _fieldDrawers = new List<TDrawer>();
        private readonly List<Type> _excludedDeclaringTypes;
        private readonly bool _excludeInternal;
        private readonly BindingFlags _bindingFlags;

        protected InspectorFieldsDrawer(
            List<Type> excludedDeclaringTypes = null,
            bool excludeInternal = true,
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
        {
            _excludedDeclaringTypes = excludedDeclaringTypes ?? new List<Type>();
            _excludeInternal = excludeInternal;
            _bindingFlags = bindingFlags;

            RegisterDrawers();
        }

        protected IEnumerable<(TDrawer fieldDrawer, FieldInfo field, object value)> GetProcessedFields(object target)
        {
            FieldInfo[] fields = GetSerializableFields(target.GetType());

            foreach (FieldInfo field in fields)
            {
                TDrawer drawer = GetFieldDrawerType(field.FieldType);

                if (drawer == null || drawer.ShouldCreateInstanceIfNull())
                {
                    object value = FieldUtility.EnsureFieldInstanceExists(field, target);
                    yield return (drawer, field, value);
                }
                else
                {
                    object value = field.GetValue(target);
                    yield return (drawer, field, value);
                }
            }
        }

        private FieldInfo[] GetSerializableFields(Type targetType)
        {
            if (targetType == null)
            {
                throw new ArgumentNullException(nameof(targetType));
            }

            return targetType
                .GetFields(_bindingFlags)
                .Where(field =>
                    (field.IsPublic || field.IsDefined(typeof(SerializeField), false)) &&
                    (!_excludeInternal || !field.IsAssembly) &&
                    !_excludedDeclaringTypes.Contains(field.DeclaringType))
                .ToArray();
        }

        private TDrawer GetFieldDrawerType(Type fieldType)
        {
            return _fieldDrawers.FirstOrDefault(drawer => drawer.CanDraw(fieldType));
        }
        
        private void RegisterDrawers()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                Type[] drawerTypes = assembly.GetTypes()
                    .Where(t => typeof(TDrawer).IsAssignableFrom(t) && !t.IsAbstract && t.IsClass)
                    .ToArray();

                foreach (Type drawerType in drawerTypes)
                {
                    TDrawer instance = (TDrawer)Activator.CreateInstance(drawerType);
                    _fieldDrawers.Add(instance);
                }
            }
        }
    }
}
#endif