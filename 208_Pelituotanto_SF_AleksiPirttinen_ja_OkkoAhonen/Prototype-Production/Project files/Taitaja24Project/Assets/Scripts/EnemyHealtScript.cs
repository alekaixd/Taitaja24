using UnityEngine;

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
        // T�ss� voit toteuttaa halutut toimenpiteet vihollisen kuollessa
        // Esimerkiksi tuhota peliobjekti tai k�ynnist�� kuolinoletus
        Destroy(gameObject);
    }
}
