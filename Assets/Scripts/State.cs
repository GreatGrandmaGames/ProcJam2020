using System;

namespace Grandma
{
    public class State
    {
        public Action OnEnter;
        public Action OnExit;

        public virtual State TransitionTo()
        {
            return null;
        }

        public virtual void Enter() 
        {
            OnEnter?.Invoke();
        }

        public virtual void Exit() 
        {
            OnExit?.Invoke();
        }

        public virtual void Update() { }
    }
}
