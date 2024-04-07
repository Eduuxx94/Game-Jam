using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    CollectibleManager controller;
    Shooting bullets;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponentInParent<CollectibleManager>();
        bullets = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Shooting>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            controller.CatchCollect();
            bullets.count++;
            Destroy(gameObject);
        }
    }
}
