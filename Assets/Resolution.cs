using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Resolution : MonoBehaviour
{
    private bool _isFullScreen;
    public TMP_Dropdown resolutionDropdown;
    private UnityEngine.Resolution[] resolutions;
    [SerializeField] private Toggle fullScreenToggle;

    private void Start() 
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        Load();
    }

    public void SetResolution(int resolutionIndex)
    {
        UnityEngine.Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    void Load()
    {
        int localFullscreen = PlayerPrefs.GetInt("masterFullscreen");
        if (localFullscreen == 1) 
        {
            Screen.fullScreen = true;
            fullScreenToggle.isOn = true;
        }
        else 
        {
            Screen.fullScreen = false;
            fullScreenToggle.isOn = false;
        }
    }

    public void SetFullScreen(bool isFullScreen)
    {
        _isFullScreen = isFullScreen;
        Screen.fullScreen = _isFullScreen;
        PlayerPrefs.SetInt("masterFullscreen", (_isFullScreen ? 1 : 0));
    }


    public void ResetButton() {
        fullScreenToggle.isOn = false;
        Screen.fullScreen = false;

        UnityEngine.Resolution currentResolution = Screen.currentResolution;
        Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
        resolutionDropdown.value = resolutions.Length;
        PlayerPrefs.SetInt("masterFullscreen", 1);
        Screen.fullScreen = true;
        fullScreenToggle.isOn = true;
    }
}
