using UnityEngine;

namespace HomeAssignment
{
    public class CharacterMovement
    {
        private float _speed;

        public CharacterMovement(float speed) => _speed = speed;

        public Vector3 Move(float vertical, float deltaTime)
        {
            Vector3 input = new Vector3(0, 0, vertical);
            Vector3 direction = input.normalized;
            Vector3 velocity = direction * GetModifiedSpeed(vertical);
            Vector3 moveAmount = velocity * deltaTime;

            return moveAmount;
        }

        private float GetModifiedSpeed(float velocity)
        {
            if (velocity >= 1)
                return _speed * 2;

            if (velocity < 0)
                return _speed / 2;

            return _speed;
        }
    }
}