using UnityEngine;
using System.Collections;

namespace Grandma.PF
{
    public class FiringState : State
    {
        public StateTransition StopFiringTransition { get; } = new StateTransition();

        public SubscriptionValue<int> CurrentAmmo { get; set; } 
        public PFProjectile ProjectilePrefab { get; set; }

        public FiringData Data { get; set; }
        public ProjectileData ProjectileData { get; set; }

        private float m_TimeSinceLastShot;
        private int m_CurrentShot;

        public override void Enter()
        {
            base.Enter();

            StopFiringTransition.Reset();

            m_CurrentShot = 0;

            FireShot();

            Debug.Log("Enter firing state");
        }

        public override void Exit()
        {
            base.Exit();

            Debug.Log("Exit firing state");
        }

        public override State TransitionTo()
        {
            return StopFiringTransition.CheckTransition() ?? base.TransitionTo();
        }

        public override void Update()
        {
            base.Update();

            if(Time.time - m_TimeSinceLastShot > Data.BurstData.Time)
            {
                FireShot();
            }

            if(m_CurrentShot >= Data.BurstData.Count)
            {
                StopFiringTransition.Transition();
            }
        }

        private void FireShot()
        {
            int numProjectiles = Data.BurstData.Shots[m_CurrentShot].NumberOfProjectiles;

            for (int j = 0; j < numProjectiles; j++)
            {
                LaunchProjectile();
            }

            CurrentAmmo.Value -= numProjectiles;

            m_CurrentShot++;
            m_TimeSinceLastShot = Time.time;
        }

        private void LaunchProjectile()
        {
            if(ProjectilePrefab != null)
            {
                PFProjectile projectile = Object.Instantiate(ProjectilePrefab);
                projectile.Data = ProjectileData;
            }
        }
    }
}
