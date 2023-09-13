using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float damage;

    private void Start()
    {
        speed = 10;

        damage = 1;
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
