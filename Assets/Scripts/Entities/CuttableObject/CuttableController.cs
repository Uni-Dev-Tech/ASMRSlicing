using Game.MVC;
using UnityEngine;
using Game.Data;
using Game.Events;

namespace Game.Entity.Cuttable
{
    public class CuttableController : BaseController<CuttableModel>
    {
        [SerializeField] private CuttableObjectData _data;

        protected override void PreInit()
        {
            if (model == null) model = new CuttableModel(_data);
        }

        public override void InitView(IInitiable<CuttableModel> view)
        {
            if (model == null) model = new CuttableModel(_data);

            view.Init(model);
            views.Add(view);
        }

        protected override void OnControllerEnable()
        {
            base.OnControllerEnable();

            model.OnProgressUpdate += OnProgressUpdate;

            EventHolder<LevelEvents.OnLevelStarted>.AddListener(OnLevelStarted, false);
            EventHolder<LevelEvents.OnCuttingStarted>.AddListener(OnCuttingStarted, false);
            EventHolder<LevelEvents.OnCuttingOver>.AddListener(OnCuttingOver, false);
            EventHolder<LevelEvents.OnCuttingRequest>.AddListener(OnCuttingRequest, false);
        }

        protected override void OnControllerDisable()
        {
            base.OnControllerDisable();

            model.OnProgressUpdate -= OnProgressUpdate;

            EventHolder<LevelEvents.OnLevelStarted>.RemoveListener(OnLevelStarted);
            EventHolder<LevelEvents.OnCuttingStarted>.RemoveListener(OnCuttingStarted);
            EventHolder<LevelEvents.OnCuttingOver>.RemoveListener(OnCuttingOver);
            EventHolder<LevelEvents.OnCuttingRequest>.RemoveListener(OnCuttingRequest);
        }

        private void OnLevelStarted(LevelEvents.OnLevelStarted action) => model.CallMotionStartEvent();
        private void OnCuttingStarted(LevelEvents.OnCuttingStarted action) => model.CallMotionStopEvent();
        private void OnCuttingOver(LevelEvents.OnCuttingOver action) => model.CallMotionStartEvent();
        private void OnCuttingRequest(LevelEvents.OnCuttingRequest acton) => model.CallMotionStopEvent();

        private void OnProgressUpdate(float percentage)
            => EventHolder<LevelEvents.OnProgressUpdate>.CallEvent(new LevelEvents.OnProgressUpdate(percentage));
    }
}