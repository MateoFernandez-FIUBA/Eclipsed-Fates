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
    [SerializeField] private float detectionRange;
    private bool hasSeenPlayer = false;
    private float timeSinceLastSight = 0f;
    [SerializeField] private float timeToRememberPlayer;

    private void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
        if (target != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if (distanceToPlayer <= detectionRange) 
            {
                float angRad = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x);

                float angGrad = (180 / Mathf.PI) * angRad - 90;

                transform.rotation = Quaternion.Euler(0, 0, angGrad);

                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

                hasSeenPlayer = true;
                timeSinceLastSight = 0f;
            }
        }
        else
        {
            // Si el enemigo ha visto al jugador, cuenta el tiempo desde la última vista
            if (hasSeenPlayer)
            {
                timeSinceLastSight += Time.deltaTime;

                // Si ha pasado suficiente tiempo, deja de recordar al jugador
                if (timeSinceLastSight >= timeToRememberPlayer)
                {
                    hasSeenPlayer = false;
                }
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character>().TakeDamage(damage * Time.deltaTime);
        }
    }
    public void TakeDamage(float damage)
    {
        life -= damage;
    }
}