using UnityEngine;

namespace Game.Entity.Cutting
{
    public class CuttingLineDrawerView : CuttingView
    {
        [SerializeField] private CutterDrawer _cutterDrawer;

        protected override void OnInitedEnable()
        {
            base.OnInitedEnable();

            Model.OnLevelStarted += OnLevelStarted;
            Model.OnLevelCompleted += OnLevelCompleted;
        }

        protected override void OnInitedDisable()
        {
            base.OnInitedDisable();

            Model.OnLevelStarted -= OnLevelStarted;
            Model.OnLevelCompleted -= OnLevelCompleted;
        }

        private void OnLevelStarted() => _cutterDrawer.Activate();
        private void OnLevelCompleted() => _cutterDrawer.Deactivate();
    }
}