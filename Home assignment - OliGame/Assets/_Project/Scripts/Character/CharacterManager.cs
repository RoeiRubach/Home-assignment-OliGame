using System;
using UnityEngine;

namespace HomeAssignment
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private CharacterMovement _movement;
        private CharacterAnimation _animation;
        private IUnityService _unityService;

        private void Start()
        {
            _unityService = new UnityService();
            _movement = new CharacterMovement(_speed);
            _animation = new CharacterAnimation(GetComponentInChildren<Animator>());
        }

        private void Update()
        {
            _animation.Handle(_unityService.GetAxis("Horizontal"), _unityService.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftControl)) return;
            transform.Translate(GetMoveAmount());
        }

        private Vector3 GetMoveAmount()
        {
            return _movement.Calculate(
                _unityService.GetAxis("Horizontal"),
                _unityService.GetAxis("Vertical"),
                _unityService.GetDeltaTime());
        }
    }
}