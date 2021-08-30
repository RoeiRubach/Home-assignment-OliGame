using UnityEngine;

namespace HomeAssignment
{
    public class CharacterBehaviour : MonoBehaviour, IDamageable
    {
        [SerializeField] private Transform _cameraTarget;
        private Character _character;

        private void Awake()
        {
            _character = new Character(GetComponentInChildren<Animator>());
        }

        private void Update()
        {
            _character.SetAnimations();

            if (Input.GetKey(KeyCode.LeftControl)) return;
            transform.Translate(_character.GetMoveAmount());
            SetRotation();
        }

        private void SetRotation()
        {
            Quaternion axisValue = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * _character.TurnPower, Vector3.up);
            _cameraTarget.transform.rotation *= axisValue;
            Quaternion SetRotationBasedLookTransform = Quaternion.Euler(0, _cameraTarget.transform.rotation.eulerAngles.y, 0);
            Vector3 resetYRotation = new Vector3(_cameraTarget.transform.localEulerAngles.x, 0, 0);
            _cameraTarget.transform.localEulerAngles = resetYRotation;

            transform.rotation = SetRotationBasedLookTransform;
        }

        public void Damage()
        {
            _character.TakeDamage(1);
        }
    }
}