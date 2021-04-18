using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator Healthanim;
    int HP = 4;

    void Start()
    {
        HP = 4;
    }

    public void TookDamage()
    {
        Healthanim.SetTrigger("m");
        FindObjectOfType<SoundManager>().Play("PlayerHurt");
        HP--;
    }

    public void GetHeal()
    {
        Healthanim.SetTrigger("p");
        FindObjectOfType<SoundManager>().Play("PlayerHeal");
        HP++;
    }
}
