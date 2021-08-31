using UnityEngine;

namespace HomeAssignment
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Obstacle : MonoBehaviour, IHittable
    {
        [Range(0, 3)]
        [SerializeField] private byte _damageAmount = 1;

        private void Awake()
        {
            GetComponent<Collider>().isTrigger = true;
            GetComponent<Rigidbody>().isKinematic = true;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IDamageable damageable))
                DoDamage(damageable);
        }

        public void DoDamage(IDamageable damageable) => damageable.TakeDamage(_damageAmount);
    }
}