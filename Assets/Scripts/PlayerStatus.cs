using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Health Status

public class PlayerStatus : MonoBehaviour
{
    public Health healthBar;
    public int maxHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void TakeHealthDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
