using Zenject;
using UnityEngine;

namespace Game.MVC
{
    public abstract class Initiable<T, K> : MonoBehaviour, IInitiable<T> where T : BaseModel
        where K : BaseController<T>
    {
        protected T Model { get; private set; }
        [Inject] private K _controller;

        private bool _isItInited = false;

        public void Init(T model)
        {
            if (_isItInited) return;

            Model = model;
            OnInitializing();

            _isItInited = true;
        }

        private void OnEnable() => OnInitedEnable();
        private void OnDisable() => OnInitedDisable();

        protected virtual void OnInitializing() { }
        protected virtual void OnInitedEnable() => _controller.InitView(this);
        protected virtual void OnInitedDisable() { }
    }
}