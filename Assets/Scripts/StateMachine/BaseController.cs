using UnityEngine;
using System.Collections.Generic;

namespace Game.SM
{
    public abstract class BaseController<T, K, C> : MonoBehaviour where T : BaseState
        where K : StatesBundle<T, C>
    {
        protected StateMachine stateMachine;
        protected List<K> bundles;

        private void Awake() => OnAwake();
        private void OnEnable() => OnEnableEnter();
        private void Start() => OnStart();

        private void Update() => UpdateCallbacks();
        private void FixedUpdate() => FixedUpdateCallbacks();
        private void LateUpdate() => LateUpdateCallbacks();

        private void OnDisable() => OnDisableEvent();
        private void OnDestroy() => OnDestroyEvent();

        private void UpdateCallbacks()
        {
            stateMachine?.CurrentState?.HandleInput();
            stateMachine?.CurrentState?.LogicUpdate();
        }

        private void FixedUpdateCallbacks()
        {
            stateMachine?.CurrentState?.PhysicsUpdate();
        }

        private void LateUpdateCallbacks()
        {
            stateMachine?.CurrentState?.LateUpdate();
        }

        protected virtual void OnAwake()
        {
            stateMachine = new StateMachine();
        }

        protected virtual void OnEnableEnter() { }
        protected virtual void OnStart() { }
        protected virtual void OnDisableEvent() { }
        protected virtual void OnDestroyEvent() { }

        public void SetState(C match) 
            => stateMachine.SetState(bundles.Find(x => Equals(x.Type, match)).State);
    }
}