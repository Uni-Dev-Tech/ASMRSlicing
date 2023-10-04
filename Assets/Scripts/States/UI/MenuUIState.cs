using Game.UI.Menu;

namespace Game.SM
{
    public class MenuUIState : BaseUIState
    {
        private MenuUIController _menuController;

        public MenuUIState(UISMController controller, MenuUIController menuController)
            : base(controller)
        { _menuController = menuController; }

        public override void Enter()
        {
            base.Enter();

            _menuController?.Activate();
        }

        public override void Exit()
        {
            base.Exit();

            _menuController?.Deactivate();
        }
    }
}