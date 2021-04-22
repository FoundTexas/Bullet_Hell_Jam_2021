using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] LeftRooms;
    public GameObject[] RightRooms;
    public GameObject[] TopRooms;
    public GameObject[] BottomRooms;


    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;
    public List<GameObject> NPCs;
    public GameObject[] Spawner;

    GameObject EXIT;

    void Update()
    {

        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    EXIT = Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    rooms.RemoveAt(i);
                    spawnedBoss = true;
                    
                }
            }
            SpawnNPCs();
        }
        else if (!spawnedBoss)
        {
            waitTime -= Time.deltaTime;
        }
    }
    void SpawnNPCs()
    {
        if (rooms.Count <= 5)
        {
            int r1 = Random.Range(0, NPCs.Count);
            int r2 = Random.Range(1, rooms.Count - 1);

            EXIT.GetComponent<ExitLevel>().SetKeys(1);
            Instantiate(NPCs.ToArray()[r1], rooms[r2].transform.position, Quaternion.identity);
            rooms.Remove(rooms[r2]);

            SetSpawners();

        }
        if (rooms.Count > 5)
        {
            EXIT.GetComponent<ExitLevel>().SetKeys(2);
            for (int i = 0; i < 2; i++)
            {
                int r1 = Random.Range(0, NPCs.Count);
                int r2 = Random.Range(1, rooms.Count);
                Instantiate(NPCs.ToArray()[r1], rooms.ToArray()[r2].transform.position, Quaternion.identity);
                NPCs.Remove(NPCs.ToArray()[r1]);
                rooms.RemoveAt(r2);

                SetSpawners();
            }

        }
    }

    void SetSpawners()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            int r2 = Random.Range(1, rooms.Count);
            Instantiate(Spawner[Random.Range(0,Spawner.Length)], rooms.ToArray()[r2].transform.position, Quaternion.identity);
          
            rooms.RemoveAt(r2);

        }
    }
}
