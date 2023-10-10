using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneTool : MonoBehaviour
{
    [SerializeField] private bool canPickUp = false;
    public CloneMachine cloneMachine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = false;
        }
    }

    public void PickUP()
    {
        if(canPickUp) 
        {
            cloneMachine.SetCloneTool();
            Destroy(gameObject);
        }
    }
}
