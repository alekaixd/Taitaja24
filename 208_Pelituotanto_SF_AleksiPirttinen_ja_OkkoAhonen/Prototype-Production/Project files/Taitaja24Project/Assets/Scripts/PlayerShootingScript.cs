using UnityEngine;

public class PlayerShootingScript : MonoBehaviour
{
    public float fireRate = 0.5f; // Projektiilin ammuntataajuus (sekunteina)
    public Transform projectileSpawnPoint; // Paikka, josta projektiilit luodaan
    public GameObject projectilePrefab; // Projektiilin prefab

    private float nextFireTime;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        Vector2 shootingDirection = Vector2.right; // Oletus ammunta suunta

        // Katso pelaajan suuntaa ja vaihda ammunta suuntaa tarvittaessa
        if (Input.GetAxis("Horizontal") < 0)
        {
            shootingDirection = Vector2.left;
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.velocity = new Vector2(shootingDirection.x * 10f, shootingDirection.y * 10f);

            // Voit myös kääntää projektiilin spritea pelaajan katsomaan suuntaan
            if (shootingDirection.x < 0)
            {
                // Käännä sprite vasemmalle
                projectile.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                // Käännä sprite oikealle
                projectile.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}
