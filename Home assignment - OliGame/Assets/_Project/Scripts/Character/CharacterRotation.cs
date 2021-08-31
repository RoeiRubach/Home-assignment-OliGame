using UnityEngine;

namespace HomeAssignment
{
    public class CharacterRotation : MonoBehaviour
    {
        public Quaternion BasedRotation { get; private set; }
        private float _turnPower = .4f;
        private Transform _transform;

        private void Start() => _transform = transform;

        private void Update() => SetRotation();

        private void SetRotation()
        {
            Quaternion axisValue = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * _turnPower, Vector3.up);
            _transform.rotation *= axisValue;
            BasedRotation = Quaternion.Euler(0, _transform.rotation.eulerAngles.y, 0);
            Vector3 resetYRotation = new Vector3(_transform.localEulerAngles.x, 0, 0);
            _transform.localEulerAngles = resetYRotation;
        }
    }
}
