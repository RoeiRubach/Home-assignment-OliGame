using UnityEngine;

namespace HomeAssignment
{
    public class CharacterAnimation
    {
        private Animator _animator;

        private string _verticalParameter = "Vertical velocity";
        private int _isCrouchID;

        public CharacterAnimation(Animator animator)
        {
            _animator = animator;
            _isCrouchID = Animator.StringToHash("IsCrouch");
        }

        public void Handle(float vertical)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                _animator.SetBool(_isCrouchID, true);
                return;
            }

            _animator.SetBool(_isCrouchID, false);
            HandleVerticalWalking(vertical);
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