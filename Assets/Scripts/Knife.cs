using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private Transform Weapon;
    [SerializeField] private float radius;
    [SerializeField] private float damage;

    private void Start()
    {
        radius = 0.5f;
        damage = 100f;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Attack();
        }
    }

    public void Attack()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(Weapon.position, radius);

        foreach(Collider2D collider in objects)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.transform.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }
}
