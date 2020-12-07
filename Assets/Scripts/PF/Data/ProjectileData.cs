using System;
using UnityEngine;

namespace Grandma.PF
{
    /// <summary>
    /// All data that defines a projectile, as fired by a PF
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "PF/Projectile Data")]
    public class ProjectileData
    {
        [Header("Impact Damage")]
        [Tooltip("The base damage caused by an impact of a projectile on a Damageable object. A negative value will heal")]
        [SerializeField]
        public int ImpactDamage;
        [Tooltip("The rate of damage change over distance travelled. Measured in 1/meters.")]
        [SerializeField]
        public int ImpactDamageChangeByDistance;


        [Header("Area of Effect Damage")]
        [Tooltip("Does this projectile explode")]
        [SerializeField]
        public bool Explodable;
        [Tooltip("The damage caused if distance to impact is zero")]
        [SerializeField]
        public int MaxExplosionDamage;
        [Tooltip("The distance at which damage falls to zero. mEasured in meters")]
        [SerializeField]
        public float BlastRange;
        //1 = rocket like behaviour - explodes on 1st impact
        [Tooltip("The number of collisions this projectile can withstand before exploding")]
        [SerializeField]
        public int NumberOfImpactsToDetonate;


        [Header("Trajectory")]
        [Tooltip("The launch force applied to a shot projectile. Measured in Newtons")]
        [SerializeField]
        public float InitialForce;
        [Tooltip("The maximum deviation applied to a shot projectile at launch time.")]
        [SerializeField]
        public float MaxInitialSpreadAngle;
        [Tooltip("The drop off of a projectile as a percentage of its initialForce.")]
        [SerializeField]
        public float DropOffRatio;
    }
}