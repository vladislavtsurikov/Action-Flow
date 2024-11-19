#if UNITY_EDITOR
using System;
using UnityEngine;
using VladislavTsurikov.CustomInspector.Editor.Core;

namespace VladislavTsurikov.CustomInspector.Editor.IMGUI
{
    public abstract class IMGUIFieldDrawer : FieldDrawer
    {
        public abstract object Draw(Rect rect, GUIContent label, Type fieldType, object value);
    }
}
#endif