using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript2 : MonoBehaviour
{
    [SerializeField]
    private int type = 0;

    [SerializeField]
    private int rotation = 10;

    [SerializeField]
    private int bulletsAmount = 3;

    [SerializeField]
    private float fireRate = 0.1f;

    [SerializeField]
    private float angle = 0f;

    private Vector2 bulletMoveDirection;

    void Start()
    {
        Debug.Log("1");
        InvokeRepeating("Fire", 0f, fireRate);
    }
    public void ResetFRate()
    {
        CancelInvoke();
        InvokeRepeating("Fire", 0f, fireRate);
    }
    void Fire()
    {
        //Debug.Log("2");
        float angleStep = 360 / bulletsAmount;

        for (int i = 0; i < bulletsAmount; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle + angleStep * i) * Mathf.PI / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle + angleStep * i) * Mathf.PI / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = FindObjectOfType<BulletPool>().GetBullet(type);
            Debug.Log(bul);
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.GetComponent<Bullet>().SetDirection(bulDir);
            bul.SetActive(true);

            angle += rotation;

            if(angle >= 360 || angle <= (-360))
            {
                angle = 0;
            }
        }
    }
}
