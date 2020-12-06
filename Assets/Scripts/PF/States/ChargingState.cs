using UnityEngine;


namespace Grandma.PF
{
    public class ChargingState : TimedState
    {
        public ChargingData Data { get; set; }

        public StateTransition CancelTransition { get; } = new StateTransition();

        public override State TransitionTo()
        {
            return CancelTransition.CheckTransition() ?? base.TransitionTo();
        }

        public override void Enter()
        {
            base.Enter();

            CancelTransition.Reset();

            Debug.Log("Enter charging state");
        }

        public override void Exit()
        {
            base.Exit();

            Debug.Log("Exit charging state");
        }
    }
}
