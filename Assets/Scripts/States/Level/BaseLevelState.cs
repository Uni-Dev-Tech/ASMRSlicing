namespace Game.SM
{
    public class BaseLevelState : BaseState
    {
        protected LevelSMController controller;

        protected BaseLevelState(LevelSMController controller) { this.controller = controller; }
    }
}