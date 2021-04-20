using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{

    private RoomTemplates templates;

    public GameObject Spawners;

    public bool canSpawn = false;

    void Start()
    {

        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
        canSpawn = false;
    }

    public void ActivateSpawner()
    {
        if (Spawners != null)
        {
            canSpawn = true;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canSpawn)
        {
            Spawners.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canSpawn)
        {
            Spawners.SetActive(false);
        }
    }
}
