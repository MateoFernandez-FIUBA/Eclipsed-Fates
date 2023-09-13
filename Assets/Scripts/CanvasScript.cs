using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    public TextMeshProUGUI healtText;
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CallPause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public void UpdateHealt(float actualHealt, float totalHealt)
    {
        healtText.text = actualHealt.ToString("F2") + " / " + totalHealt.ToString("F2");
    }
}
