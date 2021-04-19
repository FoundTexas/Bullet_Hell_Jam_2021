using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    Animator anim;
    bool dead;

    void Start()
    {
        anim = GetComponent<Animator>();
        dead = false;
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
