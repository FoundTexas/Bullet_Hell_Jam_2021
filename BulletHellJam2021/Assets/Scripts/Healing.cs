using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public Animator HealAnim;

    void OnTriggerEnter2D(Collider2D player) {
        if(player.gameObject.CompareTag("Player")) {
            HealAnim.SetTrigger("Pickup");
            Player player1 = player.GetComponent<Player>();
            if(player1.HP < 4) {
                player1.GetHeal();
            } else if(player1.HP >= 4) {
                player1.HP = 4;
            }
            Destroy(gameObject);

        }
    }
}
