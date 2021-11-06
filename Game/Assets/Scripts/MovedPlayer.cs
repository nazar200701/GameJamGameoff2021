using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthPlayer healthPlayer;

    public Rigidbody2D rb;
    public float speed = 10f;
    public Vector2 moveVector;
    public bool faceRight = true;

    public float jumpForce = 210f;
    private bool jumpControl;
    private float jumpIteration = 0;
    public float jumpValueIteration = 60;

    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;
    void Start()
    {
        currentHealth = maxHealth;
        healthPlayer.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        Walk();
        Reflect();
        Jump();
        CheckingGround();
    }

    void Walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }
    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (onGround) { jumpControl = true; }

        }
        else { jumpControl = false; }
        if (jumpControl)
        {
            if (jumpIteration++ < jumpValueIteration)
            {
                rb.AddForce(Vector2.up * jumpForce / jumpIteration);
            }
        }
        else { jumpIteration = 0; }
    }
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthPlayer.SetHealth(currentHealth);
    }
}

