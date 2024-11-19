using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Events.GameObjectLifecycle
{
    [Name("Lifecycle/Update")]
    public class UpdateEvent : LifecycleEvent
    {
        protected internal override void Update()
        {
            Trigger.Run();
        }
    }
}