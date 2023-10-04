using Zenject;
using Game.Events;
using System.Collections.Generic;
using Game.UI.Menu;
using Game.UI.InGame;
using Game.UI.Complete;

namespace Game.SM
{
    public sealed class UISMController : BaseController<BaseUIState, UIStateBundles, UIType>
    {
        [Inject] private MenuUIController _menuController;
        [Inject] private InGameUIController _inGameController;
        [Inject] private CompleteUIController _completeController;

        protected override void OnAwake()
        {
            base.OnAwake();

            bundles = new List<UIStateBundles>()
            {
                new UIStateBundles(new NoneUIState(this), UIType.None),
                new UIStateBundles(new MenuUIState(this, _menuController), UIType.Menu),
                new UIStateBundles(new InGameUIState(this, _inGameController), UIType.InGame),
                new UIStateBundles(new CompleteUIState(this, _completeController), UIType.Complete)
            };

            base.SetState(UIType.None);

            EventHolder<LevelEvents.OnMenuEnterd>.AddListener(OnMenuEntered, false);
            EventHolder<LevelEvents.OnLevelStarted>.AddListener(OnLevelStarted, false);
            EventHolder<LevelEvents.OnComplete>.AddListener(OnComplete, false);
        }

        protected override void OnDisableEvent()
        {
            base.OnDisableEvent();

            EventHolder<LevelEvents.OnMenuEnterd>.RemoveListener(OnMenuEntered);
            EventHolder<LevelEvents.OnLevelStarted>.RemoveListener(OnLevelStarted);
            EventHolder<LevelEvents.OnComplete>.RemoveListener(OnComplete);
        }

        protected override void OnDestroyEvent()
        {
            base.OnDestroyEvent();

            base.stateMachine.CurrentState.Exit();
        }

        private void OnMenuEntered(LevelEvents.OnMenuEnterd action) => SetState(UIType.Menu);

        private void OnLevelStarted(LevelEvents.OnLevelStarted action) => SetState(UIType.InGame);

        private void OnComplete(LevelEvents.OnComplete action) => SetState(UIType.Complete);
    }
}