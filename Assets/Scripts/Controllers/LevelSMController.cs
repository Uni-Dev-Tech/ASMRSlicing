using System.Collections.Generic;
using Game.Events;
using Game.Configs;

namespace Game.SM
{
    public sealed class LevelSMController : BaseController<BaseLevelState, LevelStateBundles, LevelType>
    {
        protected override void OnAwake()
        {
            base.OnAwake();

            bundles = new List<LevelStateBundles>()
            {
               new LevelStateBundles(new NoneLevelState(this), LevelType.None),
               new LevelStateBundles(new MenuLevelState(this), LevelType.Menu),
               new LevelStateBundles(new ProccesseLevelState(this), LevelType.Cutting),
               new LevelStateBundles(new CompleteLevelState(this), LevelType.Complete)
            };

            base.SetState(LevelType.None);
        }

        protected override void OnEnableEnter()
        {
            base.OnEnableEnter();

            EventHolder<LevelEvents.OnProgressUpdate>.AddListener(OnProgressUpdate, false);
        }

        protected override void OnStart()
        {
            base.OnStart();

            base.SetState(LevelType.Menu);
        }

        protected override void OnDisableEvent()
        {
            base.OnDisableEvent();

            EventHolder<LevelEvents.OnProgressUpdate>.RemoveListener(OnProgressUpdate);
        }

        protected override void OnDestroyEvent()
        {
            base.OnDestroyEvent();

            base.stateMachine.CurrentState.Exit();
        }

        private void OnProgressUpdate(LevelEvents.OnProgressUpdate action)
        {
            if (action.Percentage >= GameConfig.Instance.GeneralConfig.AccuracyPercenage)
                SetState(LevelType.Complete);
        }
    }
}