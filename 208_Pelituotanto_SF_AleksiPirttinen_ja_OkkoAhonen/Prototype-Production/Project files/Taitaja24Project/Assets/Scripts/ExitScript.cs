using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Application.Quit();
    }
}
