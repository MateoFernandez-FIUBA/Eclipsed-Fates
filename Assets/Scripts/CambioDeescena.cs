using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeescena : MonoBehaviour
{
    // Cambia "NombreDeTuNuevaEscena" por el nombre de la escena a la que deseas cambiar
    public string nuevaEscena = "Win";


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la colisión es con un objeto que tenga la etiqueta "ObjetoDeColision"
        if (collision.gameObject.CompareTag("ObjetoDeColision"))
        {
            // Cambia a la nueva escena
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("¡Funciona!");
        }
    }
}

