using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed, dashSpeed, dashLenght, dashCoolDown;

    private float activeMoveSpeed, dashCounter, dashCoolCounter;

    public Vector2 direction;

    private Rigidbody2D rb2D;

    private Vector2 input;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        speed = 3;
        dashLenght = 0.25f;
        dashCoolDown = 5f;
        dashSpeed = 10f;
        activeMoveSpeed = speed;
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        direction = input.normalized;

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCoolDown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    public void Dash()
    {
        if (dashCoolCounter <= 0 && dashCounter <= 0)
        {
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLenght;
        }
    }

    private void FixedUpdate()
    {
        rb2D.velocity = direction * activeMoveSpeed;
    }
}
