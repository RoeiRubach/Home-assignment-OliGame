using UnityEngine;

namespace HomeAssignment
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _interactionPopUp;
        public static GameObject InteractionPopUp;

        private void Awake() => InteractionPopUp = _interactionPopUp;
    }
}