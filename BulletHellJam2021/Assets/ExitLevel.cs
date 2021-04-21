using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitLevel : MonoBehaviour
{
    public Text condition;
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
    public void SetKeys(int i)
    {
        needed = i;
        condition.text = keys + " / " + needed;
    }

    public void AddKey()
    {
        keys++;
    }
}
