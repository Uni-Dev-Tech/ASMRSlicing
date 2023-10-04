using Game.UI.InGame;
using Game.Events;

namespace Game.SM
{
    public class InGameUIState : BaseUIState
    {
        private InGameUIController _inGameController;

        public InGameUIState(UISMController controller, InGameUIController inGameController)
            : base(controller)
        { _inGameController = inGameController; }

        public override void Enter()
        {
            base.Enter();

            _inGameController?.Activate();

            EventHolder<LevelEvents.OnProgressUpdate>.AddListener(OnProgressUpdate, false);
            EventHolder<LevelEvents.OnCuttingRequest>.AddListener(OnCuttingRequest, false);
            EventHolder<LevelEvents.OnCuttingStarted>.AddListener(OnCuttingStarted, false);
            EventHolder<LevelEvents.OnComplete>.AddListener(OnComplete, false);
        }

        public override void Exit()
        {
            base.Exit();

            EventHolder<LevelEvents.OnProgressUpdate>.RemoveListener(OnProgressUpdate);
            EventHolder<LevelEvents.OnCuttingRequest>.RemoveListener(OnCuttingRequest);
            EventHolder<LevelEvents.OnCuttingStarted>.RemoveListener(OnCuttingStarted);
            EventHolder<LevelEvents.OnComplete>.RemoveListener(OnComplete);

            _inGameController?.Deactivate();
        }

        private void OnProgressUpdate(LevelEvents.OnProgressUpdate action)
            => _inGameController.SetProgressPercent(action.Percentage);

        private void OnCuttingRequest(LevelEvents.OnCuttingRequest action)
            => _inGameController?.ActivateTutorial();
        private void OnCuttingStarted(LevelEvents.OnCuttingStarted action)
            => _inGameController?.DeactivateTutorial();
        private void OnComplete(LevelEvents.OnComplete action)
            => _inGameController?.DeactivateTutorial();
    }
}