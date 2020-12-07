using UnityEngine;

namespace Grandma.PF
{
    public class ReloadState : TimedState
    {
        public ReloadData Data { get; set; }
        public SubscriptionValue<int> CurrentAmmo { get; set; }

        protected override void OnTimerFinished()
        {
            base.OnTimerFinished();

            Reload();
        }

        private void Reload()
        {
            CurrentAmmo.Value = Data.AmmoCapacity;
        }

        public override void Enter()
        {
            base.Enter();


            Debug.Log("Enter reloading state");
        }

        public override void Exit()
        {
            base.Exit();

            Debug.Log("Exit reloading state");
        }
    }
}
