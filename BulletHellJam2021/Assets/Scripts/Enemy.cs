using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    Animator anim;
    bool dead;
    bool facingRight;
    Transform target;

    void Start()
    {
        target = FindObjectOfType<Player>().transform;
        anim = GetComponent<Animator>();
        dead = false;
    }

    void Update()
    {
        if (!dead)
        {
            facingRight = (target.position.x < transform.position.x) ? false : true;
            if (facingRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }

    public void TookDamage(int d)
    {
        if (!dead)
        {
            HP = HP - d;
            if (HP <= 0)
            {
                dead = true;
                anim.SetTrigger("dead");
            }
        }
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
