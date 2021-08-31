using UnityEngine;

namespace HomeAssignment
{
    public class Character
    {
        public bool CanDamaged { get; private set; }

        private readonly CharacterMovement _movement;
        private readonly CharacterRotation _rotation;
        private readonly CharacterAnimation _animation;
        private readonly HealthManager _health;
        private float _moveSpeed = 2f;

        public Character(Animator animator, CharacterRotation rotation)
        {
            CanDamaged = true;
            _health = new HealthManager(3);
            _movement = new CharacterMovement(_moveSpeed);
            _rotation = rotation;
            _animation = new CharacterAnimation(animator);
        }

        public Vector3 GetMoveAmount() => _movement.Move(Input.GetAxis("Vertical"), Time.deltaTime);
        public Quaternion GetRotation() => _rotation.BasedRotation;
        public void SetAnimations() => _animation.Handle(Input.GetAxis("Vertical"));

        public void TakeDamage(byte amount)
        {
            _health.ReduceHealth(amount);
            CanDamaged = false;
        }

        public void SetDamagedActive() => CanDamaged = true;
    }
}