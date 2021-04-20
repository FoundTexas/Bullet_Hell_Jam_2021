using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject weapons;
    public Animator Healthanim;
    public Animator playerAnim;
    int HP;
    int lives;
    bool IsHurt = true;
    float hurtTimer;
    float startHurtTimer = 2f;

    void Start()
    {
        HP = 4;
        lives = 3;
        hurtTimer = startHurtTimer;
    }

    void Update() {

    }

    public void TookDamage()
    {
        if(IsHurt == true) {
            Healthanim.SetTrigger("m");
            FindObjectOfType<SoundManager>().Play("PlayerHurt");
            HP--;
            if(HP <= 0) {
                Die();
                //return;
            }
            IsHurt = false;
            StartCoroutine(Invulnerable());
        }
        
    }

    public void GetHeal()
    {
        Healthanim.SetTrigger("p");
        FindObjectOfType<SoundManager>().Play("PlayerHeal");
        HP++;
    }

    IEnumerator Invulnerable() {
        yield return new WaitForSeconds(3f);
        IsHurt = true;
    }

    void Die() {
        FindObjectOfType<SoundManager>().Play("HeartBreak");
        weapons.gameObject.SetActive(false);
        playerAnim.SetBool("IsDead", true);
        GetComponent<TopDownMove>().enabled = false;
        this.enabled = false;
    }

    public void RestartLevel()
    {

            FindObjectOfType<GameManager>().Dead();
    }
}
