using UnityEngine;

namespace Game.SM
{
    public class BaseState
    {
        public virtual void Enter()
        {

        }

        public virtual void HandleInput()
        {

        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {

        }

        public virtual void LateUpdate()
        {

        }

        public virtual void Exit()
        {

        }

        protected void StateLog(string stateAttachement, string currentState, string action, bool isItEnabled)
        {
            if (isItEnabled)
                Debug.Log($"{stateAttachement} - {currentState} - {action}");
        }
    }
}
