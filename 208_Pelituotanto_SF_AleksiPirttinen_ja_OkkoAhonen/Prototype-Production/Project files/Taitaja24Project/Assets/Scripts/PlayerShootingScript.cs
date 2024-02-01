using UnityEngine;
using System.Collections;

public class PlayerShootingScript : MonoBehaviour
{
    public float fireRate = 0.5f; // Projektiilin ammuntataajuus (sekunteina)
    public Transform projectileSpawnPoint; // Paikka, josta projektiilit luodaan
    public GameObject projectilePrefab; // Projektiilin prefab




    public GameObject prefabToSpawn;
    private float nextFireTime;


    private void Start()
    {

    }

    void Update()
    {
        Shoot();
        

        
            sword();
        
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
    void sword()
    {
        if (Input.GetButtonDown("Fire2")){ 
        // Määritä etäisyys, jolla prefab spawnaa pelaajan eteen
        float spawnDistance = 1.0f;

        // Määritä suunta pelaajan nykyisen katselusuunnan perusteella
        Vector2 spawnDirection = transform.right;

        // Laske spawnauspaikka
        Vector2 spawnPosition = (Vector2)transform.position + spawnDirection * spawnDistance;

        // Luo prefab ja aseta sen sijainti
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Käynnistä coroutine poistamaan prefab 0.2 sekunnin kuluttua
        StartCoroutine(RemovePrefabAfterDelay(spawnedPrefab, 0.2f));
    }
    }
    private IEnumerator RemovePrefabAfterDelay(GameObject prefabInstance, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Tarkista, ettei prefabInstance ole null, koska se voisi olla tuhottu ennen ajan kulumista
        if (prefabInstance != null)
        {
            // Poista prefab-instansti
            Destroy(prefabInstance);
        }
    }
}
