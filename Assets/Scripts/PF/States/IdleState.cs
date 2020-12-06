using UnityEngine;

namespace Grandma.PF
{
    public class IdleState : State
    {
        public StateTransition FireTransition { get; } = new StateTransition();

        public override State TransitionTo()
        {
            return FireTransition.CheckTransition() ?? base.TransitionTo();
        }

        public override void Enter()
        {
            base.Enter();

            FireTransition.Reset();

            Debug.Log("Enter idle state");
        }

        public override void Exit()
        {
            base.Exit();

            Debug.Log("Exit idle state");
        }
    }
}