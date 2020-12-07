using UnityEngine;

namespace Grandma.PF
{
    public class PF : MonoBehaviour
    {
        [SerializeField]
        private PFProjectile m_ProjectilePrefab;
        [SerializeField]
        private Transform m_BarrelTransform;

        public SubscriptionValue<int> CurrentAmmo { get; } = new SubscriptionValue<int>();

        //State Machine
        private IdleState m_IdleState;
        private ChargingState m_ChargingState;
        private FiringState m_FiringState;
        private ReloadState m_ReloadState;
        private StateMachine m_StateMachine;

        private void Awake()
        {
            CreateStateMachine();
        }

        private void LateUpdate()
        {
            m_StateMachine.Update();
        }

        private void CreateStateMachine()
        {
            m_IdleState = new IdleState();

            m_FiringState = new FiringState()
            {
                ProjectilePrefab = m_ProjectilePrefab,
                CurrentAmmo = CurrentAmmo,
                BarrelTransform = m_BarrelTransform
            };

            m_ChargingState = new ChargingState()
            {
                NextState = m_FiringState
            };

            m_ReloadState = new ReloadState()
            {
                NextState = m_IdleState,
                CurrentAmmo = CurrentAmmo
            };

            m_IdleState.FireTransition.State = m_ChargingState;
            m_IdleState.ReloadTransition.State = m_ReloadState;

            m_ChargingState.CancelTransition.State = m_IdleState;
            m_ReloadState.CancelTransition.State = m_IdleState;

            m_FiringState.StopFiringTransition.State = m_IdleState;

            m_StateMachine = new StateMachine(m_IdleState);
        }

        public void SetData(PFData data)
        {
            m_ChargingState.Data = data.ChargingData;
            m_FiringState.Data = data.FiringData;
            m_FiringState.ProjectileData = data.ProjectileData;
            m_ReloadState.Data = data.ReloadData;
            //cooldown
        }

        public void Fire()
        {
            m_IdleState.FireTransition.Transition();
        }

        public void CancelFire()
        {
            m_ChargingState.CancelTransition.Transition();
        }

        public void Reload()
        {
            m_IdleState.ReloadTransition.Transition();
        }
    }
}
