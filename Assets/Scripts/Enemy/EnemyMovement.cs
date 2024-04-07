using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject platform;
    public GameObject leftEdge;
    public GameObject rightEdge;

    Rigidbody2D player;
    Rigidbody2D rigidBody;

    PlayerMovement damage;

    Vector3 playerPos;
    Vector3 position;
    Vector3 left;
    Vector3 right;
    
    public float maxSpeed = 5f;
    float speed = 0f;
    float stopTimer = 0f;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rigidBody = GetComponent<Rigidbody2D>();
        left = leftEdge.transform.position;
        right = rightEdge.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        stopTimer -= Time.deltaTime;
        position = rigidBody.position;
        if (player != null)
            playerPos = player.position;
        if (speed == 0)
            speed = maxSpeed;
        if (PlayerClose ())
        {
            if (EdgeClose ())
                speed = 0f;
        }
        else if (EdgeClose ())
            direction *= -1; 
    }

    void FixedUpdate()
    {
        if (stopTimer <= 0)
            rigidBody.velocity = new Vector2 (direction * speed, rigidBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject != platform)
        {
            rigidBody.velocity = new Vector2 (direction * -1.5f * maxSpeed, rigidBody.velocity.y);
            stopTimer = 0.5f;
        }
        if (other.rigidbody == player)
            damage.PlayerDamage(direction);
    }

    bool PlayerClose()
    {
        if (Vector2.Distance (position, playerPos) < 10.0f)
        {
            if (position.x > playerPos.x)
                direction = -1;
            else
                direction = 1;
            return (true);
        }
        return (false);
    }

    bool EdgeClose()
    {
        if (Mathf.Abs(left.x - position.x) < 0.3f && direction < 0)
            return (true);
        if (Mathf.Abs(right.x - position.x) < 0.3f && direction > 0)
            return (true);
        return (false);
    }
}
