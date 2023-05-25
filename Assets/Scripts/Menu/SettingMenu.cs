using System.Collections.Generic;
using SavingScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Menu
{
    public class SettingMenu : MonoBehaviour
    {
        public AudioMixer audioMixer;
        public TMP_Dropdown resolutionDropdown;
        public Slider volumeSlider;
        public Toggle fullscreenToggle;
        public int currentResolutionIndex = 0;
        public float currentVolume = 0;
        public bool currentFullscreen = true;

        private Resolution[] _resolutions;

        public void Awake()
        {
            _resolutions = Screen.resolutions;
            resolutionDropdown.ClearOptions();
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.AddOptions(ResolutionConvert(_resolutions));
        
            currentVolume = volumeSlider.value;
            currentFullscreen = fullscreenToggle.isOn;
        }

        public void Start()
        {
            LoadSettings();
        }

        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("volume", volume);
            currentVolume = volume;
            SaveSystem.SavePlayerSettings(this);
        }

        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
            currentFullscreen = isFullscreen;
            SaveSystem.SavePlayerSettings(this);
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = _resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            currentResolutionIndex = resolutionIndex;
            SaveSystem.SavePlayerSettings(this);
        }
    

        private List<string> ResolutionConvert(Resolution[] resolutions)
        {
            var options = new List<string>();
            currentResolutionIndex = 0;
            for (int i = 0; i < _resolutions.Length; i++)
            {
                string option = _resolutions[i].width + " x " + _resolutions[i].height + " @ " + _resolutions[i].refreshRate + "hz";
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height &&
                    _resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
                {
                    currentResolutionIndex = i;
                }
            }

            return options;
        }

        private void LoadSettings()
        {
            PlayerSettings playerSettings = SaveSystem.LoadPlayerSettings();
            currentResolutionIndex = playerSettings.resolutionIndex;
            resolutionDropdown.value = currentResolutionIndex;
            volumeSlider.value = playerSettings.volume;
            SetVolume(playerSettings.volume);
            fullscreenToggle.isOn = playerSettings.isFullscreen;
        }
    }
}
