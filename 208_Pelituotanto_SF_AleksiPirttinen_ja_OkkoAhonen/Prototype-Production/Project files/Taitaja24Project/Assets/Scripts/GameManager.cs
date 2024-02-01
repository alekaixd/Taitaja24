using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Manages the items and hearts during gameplay and that when the game restarts you dont lose your stuff
/// </summary>
public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] heartObjects;
    public int hearts = 3;
    public int projectiles;
    public List<Item> items;
    public enum Item
    {
        SpeedBoost,
        DoubleJump,
        Projectile,
        AttackSpeed,
    }

    // scene management
    public GameObject exitDoor;
    public GameObject enterDoor;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == exitDoor)
        {
            Application.Quit();
        }

        if(collision.gameObject.CompareTag("EnterDoor"))
        {
            SceneManager.LoadScene(+1);
        }
    }

    public void LoseHeart ()
    {
        hearts--;
        if (hearts == 0) 
        {
            StartCoroutine(DyingAnimation());
        }
    }

    public IEnumerator DyingAnimation()
    {
        //animation and freeze movement
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    public void AddItem(Item addableItem)
    {
         items.Add(addableItem);
    }

    public void ReadItems()
    {
        foreach (var item in items)
        {
            if (item == Item.SpeedBoost)
            {
                player.GetComponent<movementScript>().speedMultiplier += 0.1f;
            }
            else if (item == Item.DoubleJump)
            {

            }
        }
    }
}
