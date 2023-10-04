using Game.UI.Complete;

namespace Game.SM
{
    public class CompleteUIState : BaseUIState
    {
        private CompleteUIController _completeController;

        public CompleteUIState(UISMController controller, CompleteUIController completeController)
            : base(controller)
        { _completeController = completeController; }

        public override void Enter()
        {
            base.Enter();

            _completeController?.Activate();
        }

        public override void Exit()
        {
            base.Exit();

            _completeController?.Deactivate();
        }
    }
}