using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Events.Physics
{
    [Name("Physics/On Trigger Stay")]
    public class OnTriggerStayEvent : PhysicsEvent
    {
        protected internal override void OnTriggerStay(Collider other)
        {
            Trigger.Run();
        }
    }
}