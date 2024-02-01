using UnityEngine;
using System.Collections;
public class EnemyHealthScript : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Tässä voit toteuttaa halutut toimenpiteet vihollisen kuollessa
        // Esimerkiksi tuhota peliobjekti tai käynnistää kuolinoletus
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("sword"))
        {
            Die();
        }
    }

}
