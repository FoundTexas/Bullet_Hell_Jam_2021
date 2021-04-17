using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCondition : MonoBehaviour
{
    public int items;
    public int curitems;

    public DialogueTrigger[] Evidencias;

    Animator anim;

    public AudioClip ding;
    AudioSource audios;

    public void Start()
    {
        if (PlayerPrefs.GetInt("started") == 0)
        {
            PlayerPrefs.SetInt("started", 1);
            foreach(DialogueTrigger d in Evidencias)
            {
                d.SetActive();
            }
        }

        audios = GetComponent<AudioSource>();
        audios.clip = ding;
        anim = GetComponent<Animator>();
        anim.SetBool("active", false);
    }
    public void Update()
    {
        curitems = FindObjectOfType<GameManager>().Objs;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && curitems>= items)
        {
            audios.Play();
            anim.SetBool("active",true);
            FindObjectOfType<GameManager>().NextLevel();
        }
    }
    public void add()
    {
        curitems++;
    }
    public void EndScene()
    {
        FindObjectOfType<GameManager>().NextLevel();
    }
}
