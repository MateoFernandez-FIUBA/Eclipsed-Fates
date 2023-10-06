using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalKit : MonoBehaviour
{
    [SerializeField] private float HealQuantity = 50;
    [SerializeField] private bool canPickUp = false;
    private Collider2D playerCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = true;
            playerCollider = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = false;
            playerCollider = null;
        }
    }
    public void Apply()
    {
        if (canPickUp)
        {
            playerCollider.GetComponent<Character>().TakeHeal(HealQuantity);
            Destroy(gameObject);
        }
    }
}
