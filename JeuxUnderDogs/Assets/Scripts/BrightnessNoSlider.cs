using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class BrightnessNoSlider : MonoBehaviour
{
    [SerializeField] private float defaultBrightness = 1.0f;

    public PostProcessProfile brightness;
    public PostProcessLayer layer;

    public AutoExposure exposure;
    // Start is called before the first frame update
    void Start()
    {
        brightness.TryGetSettings(out exposure);
        float bright = PlayerPrefs.GetFloat("brightness");
        AdjustBrightness(bright);
    }

    public void AdjustBrightness(float value) 
    {
        if(value != 0)
        {
            exposure.keyValue.value = value;
            PlayerPrefs.SetFloat("brightness", value);
        }
        
    }

}