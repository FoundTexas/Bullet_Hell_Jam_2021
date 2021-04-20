using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        var colliderTag = collider.CompareTag("Player");
        if(collider.tag == "Bullet")
        {}
        else if (colliderTag == false) {
            Destroy(collider.gameObject);
        }
    }
}
