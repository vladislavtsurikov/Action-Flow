using UnityEngine.EventSystems;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Events.UnityUI
{
    [Name("Unity UI/On Hover Exit")]
    public class OnHoverExitPointerEvent : UIPointerEvent
    {
        protected internal override void OnHoverExit(PointerEventData eventData)
        {
            Trigger.Run();
        }
    }
}