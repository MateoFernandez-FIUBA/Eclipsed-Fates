using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionBox : MonoBehaviour
{
    [SerializeField] private int ammo;

    private void Start()
    {
        ammo = 10;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Shoot>().PickAmmunition(ammo);
            Destroy(gameObject);
        }
    }
}
