using Game.Events;

namespace Game.SM
{
    public class MenuLevelState : BaseLevelState
    {
        public MenuLevelState(LevelSMController controller) : base(controller) { }

        public override void Enter()
        {
            base.Enter();

            EventHolder<LevelEvents.OnMenuEnterd>.CallEvent(new LevelEvents.OnMenuEnterd());

            EventHolder<UIEvents.OnMenu.OnPlayClick>.AddListener(OnPlayClick, false);
        }

        public override void Exit()
        {
            base.Exit();

            EventHolder<UIEvents.OnMenu.OnPlayClick>.RemoveListener(OnPlayClick);
        }

        private void OnPlayClick(UIEvents.OnMenu.OnPlayClick action)
            => base.controller.SetState(LevelType.Cutting);
    }
}