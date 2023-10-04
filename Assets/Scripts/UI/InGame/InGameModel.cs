using System;

namespace Game.UI.InGame
{
    public class InGameModel : BaseUIModel
    {
        public event Action<float> OnProgressSet;

        public event Action OnTutorialActivate;
        public event Action OnTutorialDeactivate;

        public void CallProgressSetEvent(float value) => OnProgressSet?.Invoke(value);

        public void CallTutorialActivationEvent() => OnTutorialActivate?.Invoke();
        public void CallTutotialDeactivationEvent() => OnTutorialDeactivate?.Invoke();
    }
}