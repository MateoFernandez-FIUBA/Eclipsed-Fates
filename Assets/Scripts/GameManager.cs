using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UIManager uiManager;
    public SaveControl saveControl;
    [SerializeField] GameObject deadScreen;
    [SerializeField] CharacterMovement characterMovement;

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

    private void Start()
    {
        Time.timeScale = 1.0f;
        Application.targetFrameRate = 300;
        saveControl.LoadData();
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            characterMovement.DashCondition(false);
        }
        else
        {
            characterMovement.DashCondition(true);
        }
    }

    public void GameOver()
    {
        //Hara lo que tenga que hacer xd
        uiManager.ShowPanel(deadScreen);
        Time.timeScale = 0f;
    }

}
