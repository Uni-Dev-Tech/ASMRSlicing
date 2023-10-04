namespace Game.SM
{
    public class BaseUIState : BaseState
    {
        protected UISMController controller;

        protected BaseUIState(UISMController controller) { this.controller = controller; }
    }
}