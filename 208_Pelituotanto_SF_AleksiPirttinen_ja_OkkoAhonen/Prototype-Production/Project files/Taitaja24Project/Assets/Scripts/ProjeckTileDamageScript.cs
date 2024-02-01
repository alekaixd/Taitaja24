using UnityEngine;

public class ProjecktileDamageScript : MonoBehaviour
{
    public int damage = 25; // Aseta haluamasi vahinkoarvo Unity Editorissa

    void Start()
    {
        // Voit lisätä tässä lisätoimintoja, jos tarpeen
        Debug.Log("toimii");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Tarkista, onko törmätty viholliseen tai muuhun peliobjektiin
        if (other.CompareTag("enemy"))
        {
            // Kutsu vihollisen vahingoittamiseen liittyvää koodia
            EnemyHealthScript enemyHealth = other.GetComponent<EnemyHealthScript>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Voit myös lisätä muita toimintoja tai tuhota projektiilin tässä
            Destroy(gameObject);
        }
        /*else if (other.CompareTag("Obstacle"))
        {
            // Käsittele esteeseen osumista tarvittaessa
            // Voit lisätä toimintoja tai tuhota projektiilin tässä
            Destroy(gameObject);
        }*/
    }
}
