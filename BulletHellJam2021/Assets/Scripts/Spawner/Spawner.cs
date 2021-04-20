using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Enemies;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        int r = Random.Range(0, 3);
        switch (r) {
            case 0:
                Instantiate(Enemies[Random.Range(0, Enemies.Length)],this.transform.position,Quaternion.identity,this.transform);
                break;
            case 1:
                Instantiate(Enemies[1], this.transform.position, Quaternion.identity, this.transform);
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
        
    }
}
