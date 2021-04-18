using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator Healthanim;
    public Animator playerAnim;
    int HP;
    bool IsHurt = true;
    float hurtTimer;
    float startHurtTimer = 2f;

    void Start()
    {
        HP = 4;
        hurtTimer = startHurtTimer;
    }

    void Update() {

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

    void Death() {
        playerAnim.SetBool("IsDead", true);
        GetComponent<TopDownMove>().enabled = false;
        this.enabled = false;
    }
}
