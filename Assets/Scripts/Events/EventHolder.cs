using System;
using System.Collections.Generic;

namespace Game.Events
{
    public class EventHolder<T> where T : class
    {
        private static readonly List<Action<T>> _listreners = new List<Action<T>>();

        private static T _currentInfoState;

        public static void AddListener(Action<T> listener, bool instantNotify)
        {
            _listreners.Add(listener);
            if (instantNotify && _currentInfoState != null)
                listener?.Invoke(_currentInfoState);
        }

        public static void CallEvent(T state)
        {
            _currentInfoState = state;
            foreach (var listener in _listreners.ToArray())
                listener?.Invoke(state);
        }

        public static void RemoveListener(Action<T> listener)
        {
            if (_listreners.Contains(listener))
                _listreners.Remove(listener);
        }
    }
}
