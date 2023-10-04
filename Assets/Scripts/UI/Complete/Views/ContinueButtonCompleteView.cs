using UnityEngine;

namespace Game.UI.Complete
{
    public class ContinueButtonCompleteView : CompleteUIView
    {
        [SerializeField] private ContinueButton _clickReceiver;

        protected override void OnInitedEnable()
        {
            base.OnInitedEnable();

            _clickReceiver.Sub(Model.CallContinueClickEvent);
        }

        protected override void OnInitedDisable()
        {
            base.OnInitedDisable();

            _clickReceiver.Unsub(Model.CallContinueClickEvent);
        }
    }
}