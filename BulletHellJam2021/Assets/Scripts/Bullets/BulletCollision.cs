using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCollision : MonoBehaviour
{
    public ParticleSystem bulletExplode;
    public GameObject pop_text;
    public bool isEnemy;
    public int BulletDamage;

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("collision");

        if (isEnemy)
        {

            if (collider.gameObject.CompareTag("Player"))
            {
                Instantiate(bulletExplode, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                collider.GetComponent<Player>().TookDamage();
            }
            else if (collider.gameObject.CompareTag("Obstacle"))
            {
                Instantiate(bulletExplode, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }
        else if (!isEnemy)
        {

            if (collider.gameObject.CompareTag("Enemy"))
            {
                Instantiate(bulletExplode, transform.position, Quaternion.identity);
                GameObject dmg = Instantiate(pop_text, transform.position, Quaternion.identity);
                dmg.GetComponentInChildren<Text>().text = BulletDamage + "";
                Destroy(gameObject);
                collider.GetComponent<Enemy>().TookDamage(BulletDamage);
            }
            else if (collider.gameObject.CompareTag("Obstacle"))
            {
                Instantiate(bulletExplode, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
