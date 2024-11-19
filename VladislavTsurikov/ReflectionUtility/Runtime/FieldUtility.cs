using System;
using System.Reflection;

namespace VladislavTsurikov.ReflectionUtility.Runtime
{
    public static class FieldUtility
    {
        public static object EnsureFieldInstanceExists(FieldInfo field, object target)
        {
            object value = field.GetValue(target);

            if (value == null && field.FieldType.IsClass)
            {
                var constructor = field.FieldType.GetConstructor(Type.EmptyTypes);

                if (constructor != null)
                {
                    value = Activator.CreateInstance(field.FieldType);
                    field.SetValue(target, value);
                }
            }

            return value;
        }
    }
}