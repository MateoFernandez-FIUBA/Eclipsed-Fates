using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuncionBotones : MonoBehaviour
{
    public void Jugar()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
