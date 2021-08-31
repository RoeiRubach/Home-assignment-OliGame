using System;
using UnityEngine;

namespace HomeAssignment
{
    public class HealthManager
    {
        public static Action<byte> OnGettingDamage;
        private byte _healthPoints, _maxHealthPoints;

        public HealthManager(byte healthAmount)
        {
            _maxHealthPoints = healthAmount;
            SetHealthToMax();
        }

        public void ReduceHealth(byte damageAmount)
        {
            _healthPoints = (byte)Mathf.Clamp(_healthPoints - damageAmount, 0, _maxHealthPoints);
            OnGettingDamage?.Invoke(_maxHealthPoints);
        }

        public void SetHealthToMax() => _healthPoints = _maxHealthPoints;
    }
}