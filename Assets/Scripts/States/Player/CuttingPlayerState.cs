using Game.Events;
using Game.Inputer;

namespace Game.SM
{
    public class CuttingPlayerState : BasePlayerState
    {
        private InputHandler _inputHandler;

        public CuttingPlayerState(PlayerSMController controller, InputHandler inputHandler)
            : base(controller)
        { _inputHandler = inputHandler; }

        public override void Enter()
        {
            base.Enter();

            _inputHandler.OnUnpress += OnUnpress;
        }

        public override void HandleInput()
        {
            base.HandleInput();
            
            _inputHandler.Update();
        }

        public override void Exit()
        {
            base.Exit();

            _inputHandler.OnUnpress += OnUnpress;
        }

        private void OnUnpress()
        {
            EventHolder<PlayerEvents.OnPlayerUnpress>.CallEvent(new PlayerEvents.OnPlayerUnpress());

            base.controller.SetState(PlayerType.Await);
        }
    }
}