using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool InstanceBP;
    public GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;

    public List<GameObject> bullets;

    private void Awake()
    {
        InstanceBP = this;
    }
    void Start()
    {
        bullets = new List<GameObject>();
    }
    public GameObject GetBullet()
    {
        Debug.Log("getting Bullets");
        if (bullets.Count > 0)
        {
            Debug.Log("op1");
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].activeInHierarchy == false)
                {
                    return bullets[i];
                }
            }
        }
        if (notEnoughBulletsInPool)
        {
            Debug.Log("op2");
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
