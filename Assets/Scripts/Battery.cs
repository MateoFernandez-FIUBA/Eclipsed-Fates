using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] private float batteryRecharge = 50;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FlashLight flashLight = collision.GetComponentInChildren<FlashLight>();
            if (flashLight != null)
            {
                flashLight.RechargeBattery(batteryRecharge);
                Destroy(gameObject);
            }
        }
    }
}
