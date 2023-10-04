namespace Game.SM
{
    public class StateMachine
    {
        public BaseState CurrentState { get; private set; }

        public void SetState(BaseState newState)
        {
            if (CurrentState == newState) return;
            else if (CurrentState != null) CurrentState.Exit();

            CurrentState = newState;
            newState.Enter();
        }
    }
}
