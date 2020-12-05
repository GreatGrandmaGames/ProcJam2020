namespace Grandma
{
    /// <summary>
    /// Manages the current state for a tool which can pierce the leg
    /// </summary>
    public class StateMachine
    {
        public State CurrentState { get; private set; }

        public StateMachine(State startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }

        public void Update()
        {
            CheckStateTransition();

            CurrentState.Update();
        }

        private void CheckStateTransition()
        {
            State nextState = CurrentState;

            while(nextState != null)
            {
                ChangeState(nextState);
                nextState = nextState.TransitionTo();
            }
        }

        private void ChangeState(State nextState)
        {
            if (nextState != CurrentState)
            {
                CurrentState.Exit();

                CurrentState = nextState;

                nextState.Enter();
            }
        }
    }
}
