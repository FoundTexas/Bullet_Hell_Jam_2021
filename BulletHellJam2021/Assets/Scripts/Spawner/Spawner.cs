using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] Enemies;

    public GameObject child;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
        target = FindObjectOfType<Player>().transform;
        Spawn();
    }

    public void Spawn()
    {
        int r = Random.Range(0, 3);
        switch (r) {
            case 0:
                child = Instantiate(Enemies[Random.Range(0, Enemies.Length)],this.transform.position,Quaternion.identity);
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (child != null)
        {
            if (Vector2.Distance(child.transform.position, target.transform.position) > 25)
            {
                child.SetActive(false);
            }
            else
            {
                child.SetActive(true);
            }
        }
    }
}
