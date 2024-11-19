#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using VladislavTsurikov.ActionFlow.Runtime.Actions;
using VladislavTsurikov.IMGUIUtility.Editor.ElementStack.ReorderableList;

namespace VladislavTsurikov.ActionFlow.Editor
{
    [CustomEditor(typeof(AssetActions))]
    public class AssetActionsEditor : UnityEditor.Editor
    {
        private AssetActions _settings;
        
        private ReorderableListStackEditor<Action, ReorderableListComponentEditor> _actionsCollectionEditor;

        private void OnEnable()
        {
            _settings = (AssetActions)target;
            
            _actionsCollectionEditor = new ReorderableListStackEditor<Action, ReorderableListComponentEditor>(
                new GUIContent("Actions"), _settings.ActionCollection, true);
        }
        
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            
            _actionsCollectionEditor.OnGUI();
            
            if(EditorGUI.EndChangeCheck())
            {
                _settings.SetDirtyAssetActions();
            }
        }
    }
}
#endif