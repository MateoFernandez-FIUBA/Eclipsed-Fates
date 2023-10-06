using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionBox : MonoBehaviour
{
    [SerializeField] private int ammo;
    [SerializeField] private bool canPickUp = false;
    private Collider2D playerCollider;

    private void Start()
    {
        ammo = 10;
    }
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
        if(canPickUp) 
        {
            playerCollider.GetComponent<Shoot>().PickAmmunition(ammo);
            Destroy(gameObject);
        }
    }
}
