namespace Game.SM
{
    public class BasePlayerState : BaseState
    {
        protected PlayerSMController controller;

        protected BasePlayerState(PlayerSMController controller) { this.controller = controller; }
    }
}