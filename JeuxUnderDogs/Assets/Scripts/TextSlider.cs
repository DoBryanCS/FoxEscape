using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSlider : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private float defaultVolume = 1.0f;


    private void Start() 
    {
       Load();
    }

    void Load() 
    {
        slider.value = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.volume = slider.value;
    }

    public void Save() 
    {
        PlayerPrefs.SetFloat("musicVolume", slider.value);
        Load();
    }

    public void ResetButton()
    {
        AudioListener.volume = defaultVolume;
        slider.value = defaultVolume;
        PlayerPrefs.SetFloat("musicVolume", slider.value);

    }
}
