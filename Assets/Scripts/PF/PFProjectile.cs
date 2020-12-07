using UnityEngine;


namespace Grandma.PF
{
    public interface IDamageable
    {
        void Damage(int amount);
        Vector3 Position { get; }
    }

    public class PFProjectile : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody m_Rigidbody;

        public ProjectileData Data { get; set; }

        //Calculated properties
        private float m_DistanceTravelled = 0.0f;
        private Vector3? m_PreviousPosition = null; //used for previousPosition
        private int m_NumberOfCollisions; //used for explosion

        //private PFProjectileData projData;

        //private Agent firingAgent;
        //private ParametricFirearm firingPF;

        private bool m_IsLaunched;

        public void Launch()
        {
            ApplyStartingTrajectory();
            m_IsLaunched = true;
        }

        private void FixedUpdate()
        {
            if(m_IsLaunched == false)
            {
                return;
            }

            //Motion
            AddAdditionalForces();

            //Record distance travelled
            if (m_PreviousPosition.HasValue)
            {
                m_DistanceTravelled += Vector3.Distance(m_PreviousPosition.Value, transform.position);
            }

            m_PreviousPosition = transform.position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            m_NumberOfCollisions++;

            var hitMax = m_NumberOfCollisions >= Data.NumberOfImpactsToDetonate;
            var damageable = collision.transform.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(CalculateDamageOnImpact());

                TryExplode();
            }
            else if (hitMax)
            {
                TryExplode();
            }
        }

        private void ApplyStartingTrajectory()
        {
            //Generate any projectile specific random values
            float trajectoryScalarX = RandomUtility.RandFloat(-1f, 1f);
            float trajectoryScalarY = RandomUtility.RandFloat(-1f, 1f);

            Vector3 forceVector = transform.forward;

            forceVector += transform.right * Mathf.Tan(trajectoryScalarX) * Data.MaxInitialSpreadAngle;
            forceVector += transform.up * Mathf.Tan(trajectoryScalarY) * Data.MaxInitialSpreadAngle;

            forceVector = forceVector.normalized * Data.InitialForce;

            m_Rigidbody.AddForce(forceVector, ForceMode.Impulse);
        }

        private void AddAdditionalForces()
        {
            //Gravity
            //Why do we multiply by initialSpeed here?
            //If we just applied some drop off force, this would be a NON-ORTHONGONAL feature
            //because the faster your initial speed, the less dropoff has time to affect the course 
            //of the projetile.
            //Here, the initial speed is included so that no matter how fast the projectile travels,
            //the same dropoff ratio for one gun is the same for another (with a different initial speed)
            m_Rigidbody.AddForce(Vector3.down * Data.DropOffRatio * Data.InitialForce / Time.fixedDeltaTime);
        }

        private void TryExplode()
        {
            if (Data.Explodable == false)
            {
                return;
            }

            foreach (Collider col in Physics.OverlapSphere(transform.position, Data.BlastRange))
            {
                IDamageable damageable = col.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    damageable.Damage(CalculateDamageOnExplosion(damageable.Position));
                }
            }

            Destroy(gameObject);
        }

        private int CalculateDamageOnImpact()
        {
            return Data.ImpactDamage + (int)(Data.ImpactDamageChangeByDistance * m_DistanceTravelled);
        }

        private int CalculateDamageOnExplosion(Vector3 otherPosition)
        {
            float dist = Vector3.Distance(transform.position, otherPosition);

            return Mathf.Max(0, (int)((1 - (dist / Data.BlastRange)) * Data.MaxExplosionDamage));
        }
    }
}