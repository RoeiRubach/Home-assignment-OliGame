using System;
using UnityEngine;

namespace HomeAssignment
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private CharacterMovement _movement;
        private IUnityService _unityService;

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _movement = new CharacterMovement(_speed);
            if (_unityService == null)
                _unityService = new UnityService();


        }

        private void Update()
        {
            HandleWalking();

            transform.Translate(_movement.Calculate(
                _unityService.GetAxisRaw("Horizontal"),
                _unityService.GetAxisRaw("Vertical"),
                _unityService.GetDeltaTime()));
        }

        private void HandleWalking()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _animator.SetBool("IsWalk", true);

                HandleRunning();
                return;
            }

            _animator.SetBool("IsWalk", false);
        }

        private void HandleRunning()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animator.SetBool("IsRun", true);
                return;
            }

            _animator.SetBool("IsRun", false);
        }
    }
}