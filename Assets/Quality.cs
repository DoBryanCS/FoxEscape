using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quality : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown qualityDropdown;
    private int _qualityLevel;
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex;
    }

    void Load()
    {
        int localQuality = PlayerPrefs.GetInt("masterQuality");
        qualityDropdown.value = localQuality;
        QualitySettings.SetQualityLevel(localQuality);
    }
    
    public void Save()
    {
        SetQuality(qualityDropdown.value);
        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);
        Load();
    }

    public void ResetButton() {
        qualityDropdown.value = 1;
        QualitySettings.SetQualityLevel(1);
    }
    
}
