using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private void Start()
    {
        life = 5;
        speed = 1.5f;
        damage = 25;
    }

    private void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
        float angRad = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x);

        float angGrad = (180 / Mathf.PI) * angRad - 90;

        transform.rotation = Quaternion.Euler(0, 0, angGrad);

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character>().TakeDamage(damage*Time.deltaTime);
        }
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
    }
}
