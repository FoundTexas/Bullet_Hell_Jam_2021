using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject closedRoom;
    public int OpeningDirection;
    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn() {
        if(spawned == false) {
            if(OpeningDirection == 1) {
            // bottom door
            rand = Random.Range(0, templates.BottomRooms.Length);
            Instantiate(templates.BottomRooms[rand], transform.position, Quaternion.identity);
            } else if(OpeningDirection == 2) {
            // top door
            rand = Random.Range(0, templates.BottomRooms.Length);
            Instantiate(templates.TopRooms[rand], transform.position, Quaternion.identity);
            } else if(OpeningDirection == 3) {
            // left door
            rand = Random.Range(0, templates.BottomRooms.Length);
            Instantiate(templates.LeftRooms[rand], transform.position, Quaternion.identity);
            } else if(OpeningDirection == 4) {
            // right door
            rand = Random.Range(0, templates.BottomRooms.Length);
            Instantiate(templates.RightRooms[rand], transform.position, Quaternion.identity);
            }

            spawned = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Spawnpoint")) {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false) {
                // spawn walls blocking off openings
                Instantiate(closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
