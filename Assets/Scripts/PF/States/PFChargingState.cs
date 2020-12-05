using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Grandma.PF
{
    public class PFChargingState : TimedState
    {
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
