using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Events.GameObjectLifecycle
{
    [Name("Lifecycle/Awake")]
    public class AwakeEvent : LifecycleEvent
    {
        protected internal override void Awake()
        {
            Trigger.Run();
        }
    }
}