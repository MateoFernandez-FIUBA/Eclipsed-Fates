using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healtText;
    [SerializeField] private GameObject pauseMenu;
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void UpdateHealt(float actualHealt, float totalHealt)
    {
        actualHealt = Mathf.Max(actualHealt, 0f);
        float showLife = (actualHealt / totalHealt) * 100f;
        healtText.text = showLife.ToString("F0") + "%";
    }
}
