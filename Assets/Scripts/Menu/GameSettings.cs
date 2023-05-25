using SavingScripts;
using UnityEngine;
using UnityEngine.Audio;

namespace Menu
{
    public class GameSettings : MonoBehaviour
    {
        public AudioMixer audioMixer;

        public void Awake()
        {
            audioMixer.SetFloat("volume", -80);
        }

        void Start()
        {
            // Initially mute the audio.
            LoadSettings();
        }

        void LoadSettings()
        {
            PlayerSettings playerSettings = SaveSystem.LoadPlayerSettings();
            if (playerSettings != null)
            {
                SetVolume(playerSettings.volume);
                SetFullscreen(playerSettings.isFullscreen);
                SetResolution(playerSettings.resolutionIndex);
            }
            else
            {
                // If there is no saved setting, set the volume to a default value.
                // Here, 0 is just an example. Replace it with your desired default volume.
                SetVolume(0); 
            }
        }

        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("volume", volume);
        }

        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution[] resolutions = Screen.resolutions;

            if (resolutionIndex < 0 || resolutionIndex >= resolutions.Length)
            {
                Debug.LogError("Invalid resolution index: " + resolutionIndex);
                return;
            }

            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
    }
}
