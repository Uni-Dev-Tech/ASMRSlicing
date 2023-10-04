using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game.MVC
{
    public abstract class BaseController<T> : MonoBehaviour where T : BaseModel
    {
        protected T model;
        protected List<IInitiable<T>> views = new List<IInitiable<T>>();

        private bool _isItInited = false;

        private void OnEnable() => OnControllerEnable();
        private void OnDisable() => OnControllerDisable();

        private void Awake() => OnControllerAwake();
        private void Start() => OnControllerStart();

        private void OnDestroy() => OnControllerDestroy();

        protected virtual void OnControllerAwake() { }

        protected virtual void OnControllerDestroy() { }

        protected virtual void OnControllerDisable() { StopAllCoroutines(); }

        protected virtual void OnControllerEnable()
        {
            Initializing();
        }

        protected virtual void OnControllerStart() { }

        private void Initializing()
        {
            if (_isItInited) return;

            PreInit();
            StartCoroutine(InitCoroutine());

            _isItInited = true;
        }

        protected abstract void PreInit();
        private IEnumerator InitCoroutine() { yield return new WaitForEndOfFrame(); Init(); }
        protected virtual void Init() { }
        public abstract void InitView(IInitiable<T> view);
    }
}