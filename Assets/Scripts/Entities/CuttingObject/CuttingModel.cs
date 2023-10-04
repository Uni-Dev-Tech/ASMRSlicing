using Game.MVC;
using System;

namespace Game.Entity.Cutting
{
    public class CuttingModel : BaseModel
    {
        public bool IsCutting { get; private set; }
        public bool IsMovingDown { get; private set; }
        public bool IsReleaseAwaiting { get; private set; }

        public event Action OnLevelStarted;
        public event Action OnLevelCompleted;

        public event Action OnMoveUp;
        public event Action OnMoveDown;

        public event Action<CuttingResult> OnCuttingStarted;
        public event Action<float> OnCuttingProcessUpdate;
        public event Action OnCuttedOff;
        public event Action OnCuttingOver;
        public event Action OnFinalRelease;

        public CuttingModel()
        {
            IsCutting = false;
            IsMovingDown = false;
            IsReleaseAwaiting = false;
        }

        public void CallLevelStartedEvent() => OnLevelStarted?.Invoke();
        public void CallLevelCompletedEvent() => OnLevelCompleted?.Invoke();

        public void CallCuttingStartEvent(CuttingResult cuttingResult)
        {
            IsCutting = true;
            OnCuttingStarted?.Invoke(cuttingResult);
        }

        public void CallCuttingProcessUpdateEvent(float percent)
            => OnCuttingProcessUpdate?.Invoke(100 - percent);

        public void CallCuttinOverEvent()
        {
            if (!IsMovingDown) return;

            IsCutting = false;
            IsReleaseAwaiting = true;
            OnCuttedOff?.Invoke();
        }

        public void CallReleaseOverEvent()
        {
            IsReleaseAwaiting = false;
            OnFinalRelease?.Invoke();
        }

        public void CallMoveUpEvent()
        {
            if (IsReleaseAwaiting)
            {
                OnCuttingOver?.Invoke();
                return;
            }

            IsMovingDown = false;
            OnMoveUp?.Invoke();
        }

        public void CallMoveDownEvent()
        {
            if (IsReleaseAwaiting) return;

            IsMovingDown = true;
            OnMoveDown?.Invoke();
        }
    }
}