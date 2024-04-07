using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    float timerMax = 0.5f;
    float timer = 0f;
    public int maxHealth = 3;
    int currentHealth;
    public int health { get { return currentHealth; }}
	public static bool death_flag = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }

    public void ChangeHealth()
    {
        if (timer <= 0)
        {
            currentHealth--;
            Debug.Log (currentHealth + "/" + maxHealth);
            if (currentHealth == 0)
			{
				death_flag = true;
				Destroy(gameObject);
			}
            timer = timerMax;
        }
    }
}
