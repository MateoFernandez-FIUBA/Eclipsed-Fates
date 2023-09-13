using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
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

    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
}
