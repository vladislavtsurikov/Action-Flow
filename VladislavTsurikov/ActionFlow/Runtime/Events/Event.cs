using Component = VladislavTsurikov.ComponentStack.Runtime.Core.Component;

namespace VladislavTsurikov.ActionFlow.Runtime.Events
{
    public abstract class Event : Component
    {
        internal Trigger Trigger;
        
        protected override void SetupComponent(object[] setupData = null)
        {
            Trigger = (Trigger)setupData[0];
        }
    }
}