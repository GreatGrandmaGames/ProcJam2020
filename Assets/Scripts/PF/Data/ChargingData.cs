using System;
using UnityEngine;

namespace Grandma.PF
{
    [Serializable]
    public class ChargingData
    {
        [Header("Charge Time")]
        [Tooltip("The time to fully charge the weapon. Measured in seconds")]
        public float ChargeTime;
        [Tooltip("Does the weapon need to be fully charged in order to fire?")]
        public bool RequireFullyCharged; //TODO
    }
}
