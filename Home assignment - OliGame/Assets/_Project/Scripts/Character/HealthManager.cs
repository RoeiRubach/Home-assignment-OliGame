using System;
using UnityEngine;

namespace HomeAssignment
{
    public class HealthManager
    {
        public static Action OnGettingDamage;
        public static Action OnPlayerDies;
        private byte _healthPoints, _maxHealthPoints;

        public HealthManager(byte healthAmount)
        {
            _maxHealthPoints = healthAmount;
            _healthPoints = _maxHealthPoints;
        }

        public void ReduceHealth(byte damageAmount)
        {
            _healthPoints -= damageAmount;
            Mathf.Clamp(_healthPoints, 0, _maxHealthPoints);

            if (_healthPoints == 0)
            {
                OnPlayerDies?.Invoke();
                return;
            }

            Debug.Log(_healthPoints);
            OnGettingDamage?.Invoke();
        }
    }
}