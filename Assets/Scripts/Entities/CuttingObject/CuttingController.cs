using Game.MVC;
using Game.Events;

namespace Game.Entity.Cutting
{
    public class CuttingController : BaseController<CuttingModel>
    {
        protected override void PreInit()
        {
            if (model == null) model = new CuttingModel();
        }

        public override void InitView(IInitiable<CuttingModel> view)
        {
            if (model == null) model = new CuttingModel();

            view.Init(model);
            views.Add(view);
        }

        protected override void OnControllerEnable()
        {
            base.OnControllerEnable();

            model.OnCuttingStarted += OnCuttingStartedCallback;
            model.OnFinalRelease += OnCuttingOverCallback;

            EventHolder<LevelEvents.OnLevelStarted>.AddListener(OnLevelStarted, false);
            EventHolder<LevelEvents.OnComplete>.AddListener(OnComplete, false);

            EventHolder<PlayerEvents.OnPlayerPress>.AddListener(OnPlayerPress, false);
            EventHolder<PlayerEvents.OnPlayerUnpress>.AddListener(OnPlayerUnpress, false);
        }

        protected override void OnControllerDisable()
        {
            base.OnControllerDisable();

            model.OnCuttingStarted -= OnCuttingStartedCallback;
            model.OnFinalRelease -= OnCuttingOverCallback;

            EventHolder<LevelEvents.OnLevelStarted>.RemoveListener(OnLevelStarted);
            EventHolder<LevelEvents.OnComplete>.RemoveListener(OnComplete);

            EventHolder<PlayerEvents.OnPlayerPress>.RemoveListener(OnPlayerPress);
            EventHolder<PlayerEvents.OnPlayerUnpress>.RemoveListener(OnPlayerUnpress);
        }

        private void OnLevelStarted(LevelEvents.OnLevelStarted action) => model.CallLevelStartedEvent();
        private void OnComplete(LevelEvents.OnComplete action) => model.CallLevelCompletedEvent();

        private void OnPlayerPress(PlayerEvents.OnPlayerPress action) => model.CallMoveDownEvent();
        private void OnPlayerUnpress(PlayerEvents.OnPlayerUnpress action) => model.CallMoveUpEvent();

        private void OnCuttingStartedCallback(CuttingResult cuttingResult)
            => EventHolder<LevelEvents.OnCuttingStarted>.CallEvent(new LevelEvents.OnCuttingStarted());
        private void OnCuttingOverCallback()
            => EventHolder<LevelEvents.OnCuttingOver>.CallEvent(new LevelEvents.OnCuttingOver());
    }
}