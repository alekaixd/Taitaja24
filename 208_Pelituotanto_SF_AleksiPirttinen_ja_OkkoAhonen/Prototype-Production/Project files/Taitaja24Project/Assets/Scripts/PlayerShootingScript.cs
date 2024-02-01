using UnityEngine;
using System.Collections;

/// <summary>
/// Player combat Script. This script controls the player's two attacks: projectile shooting and sword slashing.
/// </summary>
public class PlayerShootingScript : MonoBehaviour
{
    public float fireRate = 0.5f; // Projectile firing rate (in seconds)
    public Transform projectileSpawnPoint; // The place where the projectiles are created
    public GameObject projectilePrefab; // Projectile prefab

    public Animator animator; // Sword Animator

    public GameObject prefabToSpawn;
    private float nextFireTime;



    void Update()
    {
        Shoot();
        sword();
    }

    void Shoot() // Projectile shooting logic
    {
        
        Vector2 shootingDirection = Vector2.right; // Default shooting direction

        // Check player's direction and change shooting direction if needed
        if (Input.GetAxis("Horizontal") < 0)
        {
            shootingDirection = Vector2.left;
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            // Fire projectile
            nextFireTime = Time.time + fireRate;

            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.velocity = new Vector2(shootingDirection.x * 10f, shootingDirection.y * 10f);

            // Flip the projectile sprite to face the player's direction
            if (shootingDirection.x < 0)
            {
                // Flip sprite to the left
                projectile.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                // Flip sprite to the right
                projectile.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    void sword()
    {
        // Sword attack logic
        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetBool("SwordAttack", true);

            // Set distance at which the prefab spawns in front of the player
            float spawnDistance = 1.0f;

            // Set direction based on the player's current facing direction
            Vector2 spawnDirection = transform.right;

            // Calculate spawn position
            Vector2 spawnPosition = (Vector2)transform.position + spawnDirection * spawnDistance;

            // Instantiate the prefab and set its position
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            // Start coroutine to remove the prefab after 0.5 seconds
            StartCoroutine(RemovePrefabAfterDelay(spawnedPrefab, 0.5f));
            // Start coroutine to reset SwordAttack animation
            StartCoroutine(ResetSwordAttackStateAfterDelay(0.9f));
        }
    }

    private IEnumerator RemovePrefabAfterDelay(GameObject prefabInstance, float delay)
    {
        // Wait for a specific duration
        yield return new WaitForSeconds(delay);

        // Check if prefabInstance is not null, as it could have been destroyed before the time elapsed
        if (prefabInstance != null)
        {
            // Destroy the prefab instance
            Destroy(prefabInstance);
        }
    }

    IEnumerator ResetSwordAttackStateAfterDelay(float delay)
    {
        // Wait for a specific duration
        yield return new WaitForSeconds(delay);

        // Set SwordAttack animation state back to false
        animator.SetBool("SwordAttack", false);
    }
}
