using UnityEngine;

public class ProjecktileDamageScript : MonoBehaviour
{
    public int damage = 25; // Aseta haluamasi vahinkoarvo Unity Editorissa

    void Start()
    {
        // Voit lis�t� t�ss� lis�toimintoja, jos tarpeen
        Debug.Log("toimii");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Tarkista, onko t�rm�tty viholliseen tai muuhun peliobjektiin
        if (other.CompareTag("enemy"))
        {
            // Kutsu vihollisen vahingoittamiseen liittyv�� koodia
            EnemyHealthScript enemyHealth = other.GetComponent<EnemyHealthScript>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Voit my�s lis�t� muita toimintoja tai tuhota projektiilin t�ss�
            Destroy(gameObject);
        }
        /*else if (other.CompareTag("Obstacle"))
        {
            // K�sittele esteeseen osumista tarvittaessa
            // Voit lis�t� toimintoja tai tuhota projektiilin t�ss�
            Destroy(gameObject);
        }*/
    }
}
