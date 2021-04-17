using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string Name;
    public Conversation[] conversation;

    public AudioClip found;
    AudioSource audios;

    public void Start()
    {
        switch (PlayerPrefs.GetInt(name)){
            case 0:
                this.gameObject.SetActive(true);
                break;
            case 1:
                this.gameObject.SetActive(false);
                break;
        }
        audios = GetComponent<AudioSource>();
        audios.clip = found;
    }

    void active()
    {
        switch (PlayerPrefs.GetInt(name))
        {
            case 0:
                this.gameObject.SetActive(true);
                break;
            case 1:
                this.gameObject.SetActive(false);
                break;
        }
    }

    public void SetActive()
    {
        PlayerPrefs.SetInt(name, 0);
        active();


    }
    public void DeActive()
    {
        PlayerPrefs.SetInt(name, 1);
        active();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audios.Play();
            FindObjectOfType<DialogDisplay>().StarDialogue(conversation[PlayerPrefs.GetInt("lang")]);
            FindObjectOfType<GameManager>().Objs++;
            DeActive();
            //Destroy(this.gameObject);
        }
    }

}
