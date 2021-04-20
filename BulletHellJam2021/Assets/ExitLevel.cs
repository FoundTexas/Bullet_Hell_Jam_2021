using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    int keys = 0;
    public int needed = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (keys >= needed)
            {
                FindObjectOfType<GameManager>().NextLevel();
            }
        }
    }

    public void AddKey()
    {
        keys++;
    }
}
