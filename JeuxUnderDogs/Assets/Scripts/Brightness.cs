using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour
{
    public Slider brightnessSlider;
    [SerializeField] private float defaultBrightness = 1.0f;

    public PostProcessProfile brightness;
    public PostProcessLayer layer;

    public AutoExposure exposure;
    // Start is called before the first frame update
    void Start()
    {
        brightness.TryGetSettings(out exposure);
        brightnessSlider.value = PlayerPrefs.GetFloat("brightness");
        AdjustBrightness(brightnessSlider.value);
    }

    public void AdjustBrightness(float value) 
    {
        if(value != 0)
        {
            exposure.keyValue.value = value;
            PlayerPrefs.SetFloat("brightness", value);
        }
        else
        {
            exposure.keyValue.value = 1.0f;
        }
    }

     public void ResetButton()
    {
        exposure.keyValue.value = defaultBrightness;
        brightnessSlider.value = defaultBrightness;
        PlayerPrefs.SetFloat("brightness", brightnessSlider.value);

    }
}
