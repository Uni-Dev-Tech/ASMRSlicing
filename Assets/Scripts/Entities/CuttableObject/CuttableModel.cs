using Game.MVC;
using System;
using Game.Data;

namespace Game.Entity.Cuttable
{
    public class CuttableModel : BaseModel
    {
        public CuttableObjectData Data { get; private set; }

        public event Action OnMotionStart;
        public event Action OnMotionStop;

        public event Action<float> OnProgressUpdate;

        public CuttableModel(CuttableObjectData data) { Data = data; }

        public void CallMotionStartEvent() => OnMotionStart?.Invoke();
        public void CallMotionStopEvent() => OnMotionStop?.Invoke();

        public void CallProgressUpdateEvent(float percentage) => OnProgressUpdate?.Invoke(percentage);
    }
}