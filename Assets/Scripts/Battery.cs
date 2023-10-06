using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] private float batteryRecharge = 50;
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
            FlashLight flashLight = playerCollider.GetComponentInChildren<FlashLight>();
            if (flashLight != null)
            {
                flashLight.RechargeBattery(batteryRecharge);
                Destroy(gameObject);
            }
        }
    }
}

