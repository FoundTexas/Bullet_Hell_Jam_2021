using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public ParticleSystem bulletExplode;

    void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.CompareTag("Enemy")) {
            Instantiate(bulletExplode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(collider.gameObject.CompareTag("Obstacle")) {
            Instantiate(bulletExplode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
