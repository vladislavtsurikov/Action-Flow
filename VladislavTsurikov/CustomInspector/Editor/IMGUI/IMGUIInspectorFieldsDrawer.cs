#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using VladislavTsurikov.CustomInspector.Editor.Core;

namespace VladislavTsurikov.CustomInspector.Editor.IMGUI
{
    public class IMGUIInspectorFieldsDrawer : InspectorFieldsDrawer<IMGUIFieldDrawer>
    {
        private readonly IMGUIRecursiveFieldsDrawer _imguiRecursiveFieldsDrawer = new IMGUIRecursiveFieldsDrawer();
        private float _fieldsHeight;
        
        public IMGUIInspectorFieldsDrawer(
            List<Type> excludedDeclaringTypes = null,
            bool excludeInternal = true,
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            : base(excludedDeclaringTypes, excludeInternal, bindingFlags) { }

        public void DrawFields(object target, Rect rect)
        {
            if (target == null)
            {
                EditorGUI.LabelField(rect, "Target is null");
                return;
            }
            
            _fieldsHeight = 0;
            
            DrawFieldsRecursive(target, rect);
        }

        private void DrawFieldsRecursive(object target, Rect rect)
        {
            if (target == null)
            {
                return;
            }

            foreach (var (drawer, field, value) in GetProcessedFields(target))
            {
                Rect fieldRect = EditorGUI.IndentedRect(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight));

                if (drawer != null)
                {
                    EditorGUI.BeginChangeCheck();

                    object newValue = drawer.Draw(fieldRect, new GUIContent(ObjectNames.NicifyVariableName(field.Name)), field.FieldType, value);

                    if (EditorGUI.EndChangeCheck())
                    {
                        field.SetValue(target, newValue);
                    }

                    float fieldHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

                    _fieldsHeight += fieldHeight;
                    rect.y += fieldHeight;
                }
                else
                {
                    float recursiveFieldsHeight =
                        _imguiRecursiveFieldsDrawer.DrawRecursiveFields(value, field, fieldRect, DrawFieldsRecursive);
                    
                    _fieldsHeight += recursiveFieldsHeight;
                    rect.y = recursiveFieldsHeight;
                }
            }
        }
        
        public float GetFieldsHeight(object target)
        {
            return target == null ? EditorGUIUtility.singleLineHeight : _fieldsHeight;
        }
    }
}
#endif