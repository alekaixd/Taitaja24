using UnityEngine;
using System.Collections;

// EnemyHealthScript handles the calculation of enemy health and controls the dying behavior.
public class EnemyHealthScript : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy

    void Start()
    {
        // Initialize current health with the maximum health value
        currentHealth = maxHealth;
    }

    // Inflicts damage to the enemy and checks if it should die.
    public void TakeDamage(int damage)
    {
        // Reduce current health by the amount of damage
        currentHealth -= damage;

        // Check if the enemy's health is less than or equal to zero
        if (currentHealth <= 0)
        {
            // Perform actions for the enemy's death
            Die();
        }
    }

    // Handles actions when the enemy dies.
    void Die()
    {
        // Here, you can implement desired actions when the enemy dies
        // For example, destroy the game object or trigger death animations
        Destroy(gameObject);
    }

    // Detects collision with other 2D colliders, specifically the "sword" tag, and triggers death.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with an object tagged as "sword"
        if (collision.CompareTag("sword"))
        {
            // Trigger death when the enemy is hit by the sword
            Die();
        }
    }
}
