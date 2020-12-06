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
        public ProjectileData ProjectileData;
        public ChargingData ChargingData;
        public FiringData FiringData;
        //public CooldownData CooldownData;
    }
}