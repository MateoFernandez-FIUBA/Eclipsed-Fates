using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UIManager uiManager;
    [SerializeField] GameObject deadScreen;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        //Hara lo que tenga que hacer xd
        uiManager.ShowPanel(deadScreen);
    }

}
