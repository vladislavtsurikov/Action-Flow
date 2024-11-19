using OdinSerializer;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace VladislavTsurikov.ActionFlow.Runtime.Actions
{
    [CreateAssetMenu(fileName = "Actions", menuName = "ActionFlow/Actions")]
    public class AssetActions : SerializedScriptableObject
    {
        [OdinSerialize]
        public ActionCollection ActionCollection = new ActionCollection();
        
#if UNITY_EDITOR
        public void SetDirtyAssetActions()
        {
            EditorUtility.SetDirty(this);
        }
#endif
    }
}