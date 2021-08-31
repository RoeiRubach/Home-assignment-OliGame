using System.Collections;

namespace HomeAssignment
{
    public interface IDamageable
    {
        public void TakeDamage(byte damageAmount);
        public IEnumerator DamageableCooldown();
    }
}