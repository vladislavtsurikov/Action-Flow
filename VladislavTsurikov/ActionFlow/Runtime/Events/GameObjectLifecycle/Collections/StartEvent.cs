using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Events.GameObjectLifecycle
{
    [Name("Lifecycle/Start")]
    public class StartEvent : LifecycleEvent
    {
        protected internal override void Start()
        {
            Trigger.Run();
        }
    }
}