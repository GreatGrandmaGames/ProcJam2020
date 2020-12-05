using System;
using UnityEngine;

namespace Grandma.PF
{
    /// <summary>
    /// All data that defines a PF
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "PF/Firearm Data")]
    public class PFData
    {
        [SerializeField]
        public ProjectileData ProjectileData;
        [SerializeField]
        public RateOfFireData RateOfFire;

        [Header("Charge Time")]
        [Tooltip("The time to fully charge the weapon. Measured in seconds")]
        public float chargeTime;
        [Tooltip("Does the weapon need to be fully charged in order to fire?")]
        public bool requireFullyCharged;

        [Header("Multishot")]
        [Tooltip("The number of shots created on launch")]
        public int NumberOfShots = 1;
    }
}