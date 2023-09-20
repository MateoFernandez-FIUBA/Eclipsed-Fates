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
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void UpdateHealt(float actualHealt, float totalHealt)
    {
        healtText.text = actualHealt.ToString("F2") + " / " + totalHealt.ToString("F2");
    }
}
