using System;
using UnityEngine;

namespace HomeAssignment
{
    public class HealthManager
    {
        public static Action OnGameOver;
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

            if(_healthPoints == byte.MinValue)
            {
                // This doesn't do anything.. Just for the general idea
                OnGameOver?.Invoke();
                return;
            }

            OnGettingDamage?.Invoke(_maxHealthPoints);
        }

        public void SetHealthToMax() => _healthPoints = _maxHealthPoints;
    }
}