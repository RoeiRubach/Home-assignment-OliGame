using System;
using UnityEngine;

namespace HomeAssignment
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private float _speed, _turnPower;
        [SerializeField] private Transform _cameraTarget;
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
            _animation.Handle(_unityService.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftControl)) return;
            transform.Translate(GetMoveAmount());
            SetRotation();
        }

        private Vector3 GetMoveAmount()
        {
            return _movement.Move(
                _unityService.GetAxis("Vertical"),
                _unityService.GetDeltaTime());
        }

        private void SetRotation()
        {
            Quaternion axisValue = Quaternion.AngleAxis(_unityService.GetAxis("Horizontal") * _turnPower, Vector3.up);
            _cameraTarget.transform.rotation *= axisValue;
            Quaternion SetRotationBasedLookTransform = Quaternion.Euler(0, _cameraTarget.transform.rotation.eulerAngles.y, 0);
            Vector3 resetYRotation = new Vector3(_cameraTarget.transform.localEulerAngles.x, 0, 0);
            _cameraTarget.transform.localEulerAngles = resetYRotation;

            transform.rotation = SetRotationBasedLookTransform;
        }
    }
}