using System;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;
using VladislavTsurikov.SceneUtility.Runtime;

namespace VladislavTsurikov.ActionFlow.Runtime.Events.GameObjectLifecycle
{
    [Serializable]
    public class NestedClass
    {
        public int Value;
        public string Description;
        public InnerNestedClass InnerNested;

        [Serializable]
        public class InnerNestedClass
        {
            public bool IsEnabled;
            public float FloatValue;
        }
    }
    
    [Name("Lifecycle/On Enable")]
    public class OnEnableEvent : LifecycleEvent
    {
        public string Text;
        public bool Toggle;
        public bool ToggleTest;
        public SceneReference Scene;
        public NestedClass NestedClass;
        
        protected internal override void OnEnable()
        {
            Trigger.Run();
        }
    }
}