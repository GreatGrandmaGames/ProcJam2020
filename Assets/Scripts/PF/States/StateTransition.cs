using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grandma
{
    public class StateTransition
    {
        public State State { get; set; }

        private bool m_WillTransition;

        public void Reset()
        {
            m_WillTransition = false;
        }

        public void Transition()
        {
            m_WillTransition = true;
        }

        public State CheckTransition()
        {
            return m_WillTransition ? State : null;
        }
    }
}