using UnityEngine;

namespace Game.UI.Menu
{
    public class PlayButtonMenuView : MenuUIView
    {
        [SerializeField] private PlayButton _clickReceiver;

        protected override void OnInitedEnable()
        {
            base.OnInitedEnable();

            _clickReceiver.Sub(Model.CallPlayClickEvent);
        }

        protected override void OnInitedDisable()
        {
            base.OnInitedDisable();

            _clickReceiver.Unsub(Model.CallPlayClickEvent);
        }
    }
}