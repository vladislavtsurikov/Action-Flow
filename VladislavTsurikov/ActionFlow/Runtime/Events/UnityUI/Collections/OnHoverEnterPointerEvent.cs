using UnityEngine.EventSystems;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Events.UnityUI
{
    [Name("Unity UI/On Hover Enter")]
    public class OnHoverEnterPointerEvent : UIPointerEvent
    {
        protected internal override void OnHoverEnter(PointerEventData eventData)
        {
            Trigger.Run();
        }
    }
}