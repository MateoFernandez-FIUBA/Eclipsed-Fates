using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private Transform Weapon;
    [SerializeField] private float radius;
    [SerializeField] private float damage;
    [SerializeField] private float timeBtwAttack;
    [SerializeField] private float timeForFollowAttack;

    private void Start()
    {
        radius = 0.5f;
        damage = 1f;
        timeBtwAttack = 1f;
    }

    private void Update()
    {
        if (timeForFollowAttack > 0)
        {
            timeForFollowAttack -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Attack();
            timeForFollowAttack = timeBtwAttack;
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
