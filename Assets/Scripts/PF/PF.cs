using UnityEngine;

namespace Grandma.PF
{
    public class PF : MonoBehaviour
    {
        private PFIdleState m_IdleState;
        private PFChargingState m_ChargingState;

        private StateMachine m_StateMachine;

        private void Awake()
        {
            m_IdleState = new PFIdleState();

            State firing = new TimedState()
            {
                TargetTime = 1.0f,
                NextState = m_IdleState
            };

            m_ChargingState = new PFChargingState()
            {
                TargetTime = 1.0f,
                NextState = firing
            };

            m_IdleState.FireTransition.State = m_ChargingState;
            m_ChargingState.CancelTransition.State = m_IdleState;

            m_StateMachine = new StateMachine(m_IdleState);
        }

        private void LateUpdate()
        {
            m_StateMachine.Update();
        }

        public void Fire()
        {
            m_IdleState.FireTransition.Transition();
        }

        public void CancelFire()
        {
            m_ChargingState.CancelTransition.Transition();
        }
    }
}
