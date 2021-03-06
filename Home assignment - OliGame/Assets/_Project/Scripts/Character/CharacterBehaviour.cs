using System.Collections;
using UnityEngine;

namespace HomeAssignment
{
    [RequireComponent(typeof(BoxCollider))]
    public class CharacterBehaviour : MonoBehaviour, IDamageable
    {
        private Character _character;
        private Transform _transform;
        private IInteractable _nearestGameObject;

        private void Awake() => _character = new Character(GetComponentInChildren<Animator>(), GetComponentInChildren<CharacterRotation>());

        private void Start() => _transform = transform;

        private void Update()
        {
            if (GameManager.IsDoorInteraction) return;

            HandleInteractions();
            HandleCharacterControl();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                UIManager.InteractionPopUp.SetActive(true);
                _nearestGameObject = interactable;
                return;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_nearestGameObject != null)
            {
                UIManager.InteractionPopUp.SetActive(false);
                _nearestGameObject = null;
            }
        }

        private void HandleInteractions()
        {
            if (_nearestGameObject == null) return;

            if (Input.GetKeyDown(ControlsManager.Interaction))
            {
                _nearestGameObject.Interact();
                _nearestGameObject = null;
            }
        }

        private void HandleCharacterControl()
        {
            _character.SetAnimations();
            _transform.rotation = _character.GetRotation();

            if (GameManager.IsInputDisable) return;
            transform.Translate(_character.GetMoveAmount());
        }

        public void TakeDamage(byte amount)
        {
            if (_character.CanDamaged)
            {
                _character.TakeDamage(amount);
                StartCoroutine(DamageableCooldown());
            }
        }

        public IEnumerator DamageableCooldown()
        {
            yield return new WaitForSeconds(2);

            _character.SetDamagedActive();
        }
    }
}