using UnityEngine;

namespace Game.UI.InGame
{
    public class CutTutorialInGameView : InGameView
    {
        [SerializeField] private CuttingTutorial _cuttingTutorial;

        protected override void OnInitializing()
        {
            base.OnInitializing();

            _cuttingTutorial.Deactivate();
        }

        protected override void OnInitedEnable()
        {
            base.OnInitedEnable();

            Model.OnTutorialActivate += OnTutorialActivate;
            Model.OnTutorialDeactivate += OnTutorialDeactivate;
        }

        protected override void OnInitedDisable()
        {
            base.OnInitedDisable();

            Model.OnTutorialActivate -= OnTutorialActivate;
            Model.OnTutorialDeactivate -= OnTutorialDeactivate;
        }

        private void OnTutorialActivate() => _cuttingTutorial.Activate();
        private void OnTutorialDeactivate() => _cuttingTutorial.Deactivate();
    }
}