using UnityEngine;

namespace HomeAssignment
{
    [RequireComponent(typeof(Collider))]
    public class CrouchColliderHandler : MonoBehaviour
    {
        [SerializeField] private Vector3 _crouchCenter;
        [SerializeField] private Vector3 _crouchSize;

        private Vector3 _startingCenter;
        private Vector3 _startingSize;
        private BoxCollider _boxCollider;

        private void Start()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _startingCenter = _boxCollider.center;
            _startingSize = _boxCollider.size;
        }

        private void Update()
        {
            if (Input.GetKeyDown(ControlsManager.CrouchKey))
            {
                _boxCollider.center = _crouchCenter;
                _boxCollider.size = _crouchSize;
            }

            if (Input.GetKeyUp(ControlsManager.CrouchKey))
            {
                _boxCollider.center = _startingCenter;
                _boxCollider.size = _startingSize;
            }
        }
    }
}