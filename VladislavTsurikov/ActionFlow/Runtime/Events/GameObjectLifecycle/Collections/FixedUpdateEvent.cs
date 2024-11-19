using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Events.GameObjectLifecycle
{
    [Name("Lifecycle/Fixed Update")]
    public class FixedUpdateEvent : LifecycleEvent
    {
        protected internal override void FixedUpdate()
        {
            Trigger.Run();
        }
    }
}