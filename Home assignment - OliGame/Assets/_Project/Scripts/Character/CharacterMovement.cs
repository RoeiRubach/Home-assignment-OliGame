using UnityEngine;

namespace HomeAssignment
{
    public class CharacterMovement
    {
        private float _speed;

        public CharacterMovement(float speed) => _speed = speed;

        public Vector3 Calculate(float horizontal, float vertical, float deltaTime)
        {
            Vector3 input = new Vector3(horizontal, 0, vertical);
            Vector3 direction = input.normalized;
            Vector3 velocity = direction * GetMultipliedSpeedIfRunning();
            Vector3 moveAmount = velocity * Time.deltaTime;

            return moveAmount;
        }

        private float GetMultipliedSpeedIfRunning()
        {
            if (Input.GetKey(KeyCode.S)) return _speed;

            if (Input.GetKey(KeyCode.LeftShift))
                return _speed * 2;

            return _speed;
        }
    }
}