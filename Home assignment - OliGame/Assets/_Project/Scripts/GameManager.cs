using UnityEngine;
using UnityEngine.SceneManagement;

namespace HomeAssignment
{
    public class GameManager : MonoBehaviour
    {
        private void Awake() => LoadUserInterface();

        private void LoadUserInterface()
        {
            string settingsSceneName = "UserInterface";
            if (!SceneManager.GetSceneByName(settingsSceneName).isLoaded)
            {
                SceneManager.LoadSceneAsync(settingsSceneName, LoadSceneMode.Additive);
                return;
            }
        }
    }
}