using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionsDropDown;
    public TMP_Dropdown qualityDropDown;
    public int quality;
    public Toggle fullScreenToggle;
    Resolution[] resolutions;
    public Slider generalSoundSlider;
    public float generalSoundValue;

    private void Start()
    {
        CheckResolution();
        quality = PlayerPrefs.GetInt("QualityNumber", 2);
        qualityDropDown.value = quality;
        ChangeQuality();
        generalSoundSlider.value = PlayerPrefs.GetFloat("GeneralSound", 0.5f);
        AudioListener.volume = generalSoundValue;
        if (Screen.fullScreen)
        {
            fullScreenToggle.isOn = true;
        }
        else
        {
            fullScreenToggle.isOn = false;
        }
    }

    public void CheckResolution()
    {
        resolutions = Screen.resolutions;
        resolutionsDropDown.ClearOptions();
        List<string> options = new List<string>();
        int actualRes = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                actualRes = i;
            }
        }
        resolutionsDropDown.AddOptions(options);
        resolutionsDropDown.value = actualRes;
        resolutionsDropDown.RefreshShownValue();
        resolutionsDropDown.value = PlayerPrefs.GetInt("ResolutionNumber", 0);
    }

    public void ChangeResolution(int indexResolution)
    {
        PlayerPrefs.SetInt("ResolutionNumber", resolutionsDropDown.value);
        Resolution resolution = resolutions[indexResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ChangeQuality()
    {
        QualitySettings.SetQualityLevel(qualityDropDown.value);
        PlayerPrefs.SetInt("QualityNumber", qualityDropDown.value);
        quality = qualityDropDown.value;
    }

    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void ChangeSlider(float value)
    {
        generalSoundValue = value;
        PlayerPrefs.SetFloat("SetSound", generalSoundValue);
        AudioListener.volume = generalSoundSlider.value;
    }
}
