using Game.Inputer;
using Game.Events;

namespace Game.SM
{
    public class AwaitInputPlayerState : BasePlayerState
    {
        private InputHandler _inputHandler;

        public AwaitInputPlayerState(PlayerSMController controller, InputHandler inputHandler)
            : base(controller)
        { _inputHandler = inputHandler; }

        public override void Enter()
        {
            base.Enter();

            _inputHandler.OnPress += OnPress;
        }

        public override void HandleInput()
        {
            base.HandleInput();

            _inputHandler.Update();
        }

        public override void Exit()
        {
            base.Exit();

            _inputHandler.OnPress -= OnPress;
        }

        private void OnPress()
        {
            EventHolder<PlayerEvents.OnPlayerPress>.CallEvent(new PlayerEvents.OnPlayerPress());

            base.controller.SetState(PlayerType.Cutting);
        }
    }
}