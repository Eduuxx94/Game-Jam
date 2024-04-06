using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float timer = 0f;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isfacingRight = true;
    private bool fallDamage = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

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
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip() {
        if (isfacingRight && horizontal < 0f || !isfacingRight && horizontal > 0f) {
            isfacingRight = !isfacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
        }
    }

    public void PlayerDamage(int direction)
    {
        health.ChangeHealth();
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        timer = 0.3f;
    }
}
