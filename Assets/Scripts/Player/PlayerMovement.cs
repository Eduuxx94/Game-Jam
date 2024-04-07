using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float timer = 0f;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 18f;
    private bool isfacingRight = true;
    private bool fallDamage = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform waterCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask waterLayer;

    private Health health;
    
    void Start()
    {
        health = GetComponent<Health>();
    }

// Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (timer > 0)
            timer -= Time.deltaTime;

        if (rb.velocity.y < -30.0f)
            fallDamage = true;
        else
            fallDamage = false;

        if (IsGrounded())
        {
            if (fallDamage)
                health.ChangeHealth();
        }

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate() {
        if (timer <= 0)
        {
            if (IsWater())
            {
                if (rb.velocity.y < -8.0f)
                    rb.velocity = new Vector2(horizontal * speed * 0.60f, -8.0f);
                else if (rb.velocity.y > 13.0f)
                    rb.velocity = new Vector2(horizontal * speed * 0.60f, 13.0f);
                else
                    rb.velocity = new Vector2(horizontal * speed * 0.60f, rb.velocity.y);
            }
            else
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsWater()
    {
        return Physics2D.OverlapCircle(waterCheck.position, 0.2f, waterLayer);
    }

    private void Flip() {
        if (isfacingRight && horizontal < 0f || !isfacingRight && horizontal > 0f) {
            isfacingRight = !isfacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            if (isfacingRight)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void PlayerDamage(int direction)
    {
        health.ChangeHealth();
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        timer = 0.3f;
    }
}
