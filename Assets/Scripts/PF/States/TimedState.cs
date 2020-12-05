using UnityEngine;

namespace Grandma
{
    public class TimedState : State
    {
        public State NextState { get; set; }
        public float TargetTime { get; set; }

        private float m_EnterTimeStamp;

        public override void Enter()
        {
            base.Enter();

            m_EnterTimeStamp = Time.time;
        }

        public override State TransitionTo()
        {
            float time = Time.time - m_EnterTimeStamp;

            if(time >= TargetTime)
            {
                return NextState;
            }

            return null;
        }
    }
}
