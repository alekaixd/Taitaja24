using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<movementScript>().speedMultiplier += 0.2f;
        gameObject.SetActive(false);
    }
}
