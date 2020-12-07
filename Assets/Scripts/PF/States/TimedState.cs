using UnityEngine;

namespace Grandma
{
    public class TimedState : State
    {
        public StateTransition CancelTransition { get; } = new StateTransition();

        public State NextState { get; set; }
        public float TargetTime { get; set; }

        private float m_EnterTimeStamp;

        public override void Enter()
        {
            base.Enter();

            CancelTransition.Reset();

            m_EnterTimeStamp = Time.time;
        }

        public override State TransitionTo()
        {
            //Finished
            float time = Time.time - m_EnterTimeStamp;

            if(time >= TargetTime)
            {
                OnTimerFinished();
                return NextState;
            }

            //Cancelled
            return CancelTransition.CheckTransition() ?? base.TransitionTo();
        }

        protected virtual void OnTimerFinished() { }
    }
}
