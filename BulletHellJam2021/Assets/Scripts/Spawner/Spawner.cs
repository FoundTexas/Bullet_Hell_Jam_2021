using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool dialogue = true;
    public GameObject[] Enemies;

    public GameObject child;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = true;
        target = FindObjectOfType<Player>().gameObject;
        Spawn();
    }

    public void Spawn()
    {
        int r = Random.Range(0, 1);
        switch (r) {
            case 0:
                child = Instantiate(Enemies[Random.Range(0, Enemies.Length)],this.transform.position,Quaternion.identity);
                break;
            case 1:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (child != null)
        {
            if (!dialogue)
            {
                if (Vector2.Distance(child.transform.position, target.transform.position) > 30)
                {
                    child.SetActive(false);
                }
                else
                {
                    child.SetActive(true);
                }
            }
            else if (dialogue)
            {
                child.SetActive(false);
            }
        }
    }
}
