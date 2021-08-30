using System;
using UnityEngine;

namespace HomeAssignment
{
    public class HealthManager
    {
        public static Action OnGettingDamage;
        private byte _healthPoints;

        public HealthManager()
        {
            _healthPoints = 3;
        }

        public void ReduceHealth(byte damageAmount)
        {
            _healthPoints -= damageAmount;
            OnGettingDamage?.Invoke();
        }
    }
}