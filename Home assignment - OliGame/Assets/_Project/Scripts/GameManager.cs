using UnityEngine;
using UnityEngine.SceneManagement;

namespace HomeAssignment
{
    public class GameManager : MonoBehaviour
    {
        public static bool AreEffectsOn;
        public static float GettingHitCooldown = 2.3f;
        public static bool IsInputDisable;
        [SerializeField] private bool _areEffectOn;

        private void Awake()
        {
            LoadUserInterface();
            AreEffectsOn = _areEffectOn;
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

        private void Update()
        {
            if (Input.GetKeyDown(ControlsManager.CrouchKey))
                IsInputDisable = true;

            if (Input.GetKeyUp(ControlsManager.CrouchKey))
                IsInputDisable = false;
        }
    }
}