using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool IsPaused = false;

        public GameObject pauseMenuUI;
        public GameObject mainMenuUI;
        public GameObject settingsMenuUI;
        public GameObject GameEndUI;

    
        // Update is called once per frame
        void Update()
        {
            if (!GameEndUI.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (IsPaused)
                    {
                        Resume();
                    }
                    else
                    {
                        Pause();
                    }
                }
            }
        }

        public void Resume()
        {
            settingsMenuUI.SetActive(false);
            mainMenuUI.SetActive(true);
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }

        private void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }

        public void ReturnToMenu()
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1f;
        }

        public void QuitGame()
        {
            Debug.Log("GameQuit!!!");
            Application.Quit();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }
}
