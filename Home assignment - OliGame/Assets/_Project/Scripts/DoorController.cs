using System;
using System.Collections;
using UnityEngine;

namespace HomeAssignment
{
    [RequireComponent(typeof(BoxCollider))]
    public class DoorController : MonoBehaviour, IInteractable
    {
        public static Action<string> OnDoorInteraction;

        [SerializeField] private ScenesNames _sceneName;
        private Animation _animation;

        public bool IsInteracted { get; private set; }

        private void Start() => _animation = GetComponent<Animation>();

        public void Interact()
        {
            if (IsInteracted) return;

            GameManager.IsDoorInteraction = true;
            IsInteracted = true;
            _animation.Play();
            StartCoroutine(DoorFullyOpen());
        }

        private IEnumerator DoorFullyOpen()
        {
            while (_animation.isPlaying)
                yield return null;

            OnDoorInteraction?.Invoke(_sceneName.ToString());
        }

        private void OnDisable() => IsInteracted = false;
    }
}