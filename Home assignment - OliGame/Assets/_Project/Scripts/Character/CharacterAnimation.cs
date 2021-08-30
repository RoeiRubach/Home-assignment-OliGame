using UnityEngine;

namespace HomeAssignment
{
    public class CharacterAnimation
    {
        private Animator _animator;

        private string _verticalParameter = "Vertical velocity";
        private string _horizontalParameter = "Horizontal velocity";
        private int _isCrouchID;

        public CharacterAnimation(Animator animator)
        {
            _animator = animator;
            _isCrouchID = Animator.StringToHash("IsCrouch");
        }

        public void Handle(float horizontal, float vertical)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                _animator.SetBool(_isCrouchID, true);
                return;
            }

            _animator.SetBool(_isCrouchID, false);
            HandleLocomotion(horizontal, vertical);
        }

        private void HandleLocomotion(float horizontal, float vertical)
        {
            HandleHorizontalWalking(horizontal);
            HandleVerticalWalking(vertical);
        }

        private void HandleHorizontalWalking(float horizontal)
        {
            _animator.SetFloat(_horizontalParameter, horizontal);
            HandleRunning(_horizontalParameter, horizontal * 2);
        }

        private void HandleVerticalWalking(float vertical)
        {
            _animator.SetFloat(_verticalParameter, vertical);
            HandleRunning(_verticalParameter, vertical * 2);
        }

        private void HandleRunning(string direction, float velocity)
        {
            if (Input.GetKey(KeyCode.S)) return;

            if (Input.GetKey(KeyCode.LeftShift))
                _animator.SetFloat(direction, velocity);
        }
    }
}