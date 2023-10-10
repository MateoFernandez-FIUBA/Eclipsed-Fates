using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMachine : MonoBehaviour
{
    [SerializeField] private bool isClose = false;
    [SerializeField] private bool hasCloneTool = false;
    public SaveControl saveControl;
    private Collider2D playerCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClose = false;
        }
    }

    public void SetCloneTool()
    {
        hasCloneTool = true;
    }

    public void ClonePlayer()
    {
        if(isClose && hasCloneTool)
        {
            saveControl.SavingData();
            hasCloneTool = false;
        }
    }
}
