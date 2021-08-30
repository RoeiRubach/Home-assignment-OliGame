using UnityEngine;

namespace HomeAssignment
{
    public class Character
    {
        public float TurnPower { get; private set; } 

        private readonly CharacterMovement _movement;
        private readonly CharacterAnimation _animation;
        private readonly HealthManager _health;

        private float _moveSpeed = 2f;

        public Character(Animator animator)
        {
            TurnPower = .5f;
            _health = new HealthManager();
            _movement = new CharacterMovement(_moveSpeed);
            _animation = new CharacterAnimation(animator);
        }

        public Vector3 GetMoveAmount() => _movement.Move(Input.GetAxis("Vertical"), Time.deltaTime);
        public void SetAnimations() => _animation.Handle(Input.GetAxis("Vertical"));

        public void TakeDamage(byte amount)
        {
            _health.ReduceHealth(amount);
        }
    }
}