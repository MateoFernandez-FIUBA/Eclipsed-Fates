using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using TMPro;
using UnityEngine.Localization.Settings;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionsDropDown;
    public TMP_Dropdown qualityDropDown;
    public TMP_Dropdown languageDropDown;
    public int quality;
    public Toggle fullScreenToggle;
    Resolution[] resolutions;
    public Slider generalVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;
    public AudioMixer audioMixer;

    private void Start()
    {
        CheckResolution();
        quality = PlayerPrefs.GetInt("QualityNumber", 2);
        qualityDropDown.value = quality;
        ChangeQuality();
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
    
    public void ChangeLanguage(int language)
    {
        language = languageDropDown.value;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[language];
        PlayerPrefs.SetInt("Language", language);
    }

    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void ChangeMasterVolume()
    {
        float generalVolume = generalVolumeSlider.value;

        audioMixer.SetFloat("Master", generalVolume);   
    }
    public void ChangeSFXVolume()
    {
        float sfxVolume = sfxVolumeSlider.value;

        audioMixer.SetFloat("SFX", sfxVolume);
    }
    public void ChangeMusicVolume()
    {
        float musicVolume = musicVolumeSlider.value;

        audioMixer.SetFloat("Music", musicVolume);
    }
}
