using Game.Events;

namespace Game.SM
{
    public class CompleteLevelState : BaseLevelState
    {
        public CompleteLevelState(LevelSMController controller) : base(controller) { }

        public override void Enter()
        {
            base.Enter();

            EventHolder<LevelEvents.OnComplete>.CallEvent(new LevelEvents.OnComplete());

            EventHolder<UIEvents.OnComplete>.AddListener(OnComplete, false);
        }

        public override void Exit()
        {
            base.Exit();

            EventHolder<UIEvents.OnComplete>.RemoveListener(OnComplete);
        }

        private void OnComplete(UIEvents.OnComplete action)
            => EventHolder<GameEvents.OnNextLevel>.CallEvent(new GameEvents.OnNextLevel());
    }
}