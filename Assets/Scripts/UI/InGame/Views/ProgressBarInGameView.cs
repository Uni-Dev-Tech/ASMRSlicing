using UnityEngine;

namespace Game.UI.InGame
{
    public class ProgressBarInGameView : InGameView
    {
        [SerializeField] private LevelProgressBar _levelProgressBar;

        protected override void OnInitedEnable()
        {
            base.OnInitedEnable();

            _levelProgressBar.SetValue(0f);

            Model.OnProgressSet += OnProgressSet;
        }

        protected override void OnInitedDisable()
        {
            base.OnInitedDisable();

            Model.OnProgressSet -= OnProgressSet;
        }

        private void OnProgressSet(float percentage) => _levelProgressBar.SetValue(percentage / 100);
    }
}