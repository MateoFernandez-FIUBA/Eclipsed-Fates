using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalKit : MonoBehaviour
{
    [SerializeField] private float HealQuantity = 50;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().TakeHeal(HealQuantity);
            Destroy(gameObject);
        }
    }
}
