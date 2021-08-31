using UnityEngine;
using UnityEngine.SceneManagement;

namespace HomeAssignment
{
    public enum ScenesNames
    {
        MainMenu,
        UserInterface,
        TestScene,
        House
    }

    public class GameManager : MonoBehaviour
    {
        public static bool AreEffectsOn;
        public static float GettingHitCooldown = 2.3f;
        public static bool IsDoorInteraction;
        public static bool IsInputDisable;
        [SerializeField] private bool _areEffectOn;

        private void Awake()
        {
            LoadUserInterface();
            AreEffectsOn = _areEffectOn;
        }

        private void Start() => DoorController.OnDoorInteraction += LoadDoorIneractionScene;

        private void Update()
        {
            if (Input.GetKeyDown(ControlsManager.CrouchKey))
                IsInputDisable = true;

            if (Input.GetKeyUp(ControlsManager.CrouchKey))
                IsInputDisable = false;
        }

        private void LoadUserInterface()
        {
            string settingsSceneName = "UserInterface";
            if (!SceneManager.GetSceneByName(settingsSceneName).isLoaded)
            {
                SceneManager.LoadSceneAsync(settingsSceneName, LoadSceneMode.Additive);
                return;
            }
        }

        private void LoadDoorIneractionScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        private void OnDisable()
        {
            DoorController.OnDoorInteraction -= LoadDoorIneractionScene;
            IsInputDisable = false;
            IsDoorInteraction = false;
    }
    }
}