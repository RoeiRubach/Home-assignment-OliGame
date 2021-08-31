using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace HomeAssignment
{
    public class IKButton : MonoBehaviour, IInteractable
    {
        [SerializeField] private TwoBoneIKConstraint _target;
        [SerializeField] private float _transitionSpeed;

        public bool IsInteracted { get; private set; }

        public void Interact()
        {
            IsInteracted = true;
            _target.data.target.position = transform.GetChild(0).transform.position;
            StopAllCoroutines();
            StartCoroutine(SetWeight(1));
        }

        private void Update()
        {
            if (!IsInteracted) return;

            if (_target.data.target.position != transform.GetChild(0).transform.position)
            {
                StopAllCoroutines();
                StartCoroutine(SetWeight(0));
                IsInteracted = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                StopAllCoroutines();
                StartCoroutine(SetWeight(0));
            }
        }

        private IEnumerator SetWeight(byte toggle)
        {
            while (_target.weight != toggle)
            {
                _target.weight = Mathf.MoveTowards(_target.weight, toggle, _transitionSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}