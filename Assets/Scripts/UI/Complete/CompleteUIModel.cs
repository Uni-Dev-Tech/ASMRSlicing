using System;

namespace Game.UI.Complete
{
    public class CompleteUIModel : BaseUIModel
    {
        public event Action OnContinueClick;

        public void CallContinueClickEvent() => OnContinueClick?.Invoke();
    }
}