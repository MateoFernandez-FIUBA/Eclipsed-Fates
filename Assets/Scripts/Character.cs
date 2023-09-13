using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Character : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private float maxLife;
    [SerializeField] private float life;
    public CanvasScript canvasScript;

    void Start()
    {
        maxLife = 100;
        life = maxLife;
        canvasScript.UpdateHealt(life, maxLife);
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            IsDead();
            canvasScript.UpdateHealt(life, maxLife);
        }

        if (life >= maxLife)
        {
            life = maxLife;
            canvasScript.UpdateHealt(life, maxLife);
        }
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        canvasScript.UpdateHealt(life, maxLife);
    }

    public void TakeHeal(float heal)
    {
        life += heal;
        canvasScript.UpdateHealt(life, maxLife);
    }

    private void IsDead()
    {
        gameManager.GameOver();
    }
}