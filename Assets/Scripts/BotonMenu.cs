using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenu : MonoBehaviour
{
    public void LoadSceneOnClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
