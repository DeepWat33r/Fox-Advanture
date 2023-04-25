using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    private int _currentResolutionIndex = 0;
    
    private Resolution[] _resolutions;
    public void Start()
    {
        _resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        resolutionDropdown.value = _currentResolutionIndex;
        resolutionDropdown.AddOptions(ResolutionConvert(_resolutions));
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
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private List<string> ResolutionConvert(Resolution[] resolutions)
    {
        var options = new List<string>();
        _currentResolutionIndex = 0;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + " x " + _resolutions[i].height + " @ " + _resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                _resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                _currentResolutionIndex = i;
            }
        }

        return options;
    }
}
