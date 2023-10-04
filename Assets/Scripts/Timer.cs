using System;

namespace Game
{
    public class Timer
    {
        private bool _isItActive;

        private float _seconds;
        private float _untilValue;

        public event Action OnTimeAlarm;

        public Timer(float untilValue)
        {
            _untilValue = untilValue;
            _isItActive = false;
            _seconds = 0;
        }

        public void Update(float step)
        {
            if (!_isItActive) return;

            _seconds += step;

            if (_seconds >= _untilValue) OnTimeAlarm?.Invoke();
        }

        public void Reset() => _seconds = 0f;

        public void Activate() => _isItActive = true;
        public void Deactivate() => _isItActive = false;
    }
}