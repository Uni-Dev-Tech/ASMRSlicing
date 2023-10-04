using Game.Inputer;
using Game.Events;
using System.Collections.Generic;

namespace Game.SM
{
    public sealed class PlayerSMController : BaseController<BasePlayerState, PlayerStateBundles, PlayerType>
    {
        protected override void OnAwake()
        {
            base.OnAwake();

            InputHandler inputHandler = new InputHandler();

            bundles = new List<PlayerStateBundles>()
            {
                new PlayerStateBundles(new NonePlayerState(this), PlayerType.None),
                new PlayerStateBundles(new AwaitInputPlayerState(this, inputHandler), PlayerType.Await),
                new PlayerStateBundles(new CuttingPlayerState(this, inputHandler), PlayerType.Cutting)
            };

            base.SetState(PlayerType.None);
        }

        protected override void OnEnableEnter()
        {
            base.OnEnableEnter();

            EventHolder<LevelEvents.OnLevelStarted>.AddListener(OnLevelStarted, false);
            EventHolder<LevelEvents.OnComplete>.AddListener(OnComplete, false);
        }

        protected override void OnDisableEvent()
        {
            base.OnDisableEvent();

            EventHolder<LevelEvents.OnLevelStarted>.RemoveListener(OnLevelStarted);
            EventHolder<LevelEvents.OnComplete>.RemoveListener(OnComplete);
        }

        protected override void OnDestroyEvent()
        {
            base.OnDestroyEvent();

            base.stateMachine.CurrentState.Exit();
        }

        private void OnLevelStarted(LevelEvents.OnLevelStarted action) => SetState(PlayerType.Await);

        private void OnComplete(LevelEvents.OnComplete action) => SetState(PlayerType.None);
    }
}