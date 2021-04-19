using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDisplay : MonoBehaviour
{
    public Conversation conversation;

    public GameObject Left;
    public GameObject Right;

    public bool canContinue;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    private int LineIndex = 100;

    //private Player player;

    private AudioSource audios;

    void Start()
    {
        audios = GetComponent<AudioSource>();
        

        speakerUILeft = Left.GetComponent<SpeakerUI>();
        speakerUIRight = Right.GetComponent<SpeakerUI>();

        //speakerUILeft.Speaker = conversation.Left;
        //speakerUIRight.Speaker = conversation.Right;
    }

    public void SetPlayer()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void StarDialogue(Conversation conver)
    {
        /*Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy E in enemies)
        {
            E.enabled = false;
        }*/

        //player.GetComponent<Player>().Dialogue();
        conversation = conver;
        LineIndex = 0;
        speakerUILeft.Speaker = conversation.Left;
        speakerUIRight.Speaker = conversation.Right;
        AdvanceConversation();
    }
    public void canComt()
    {
        canContinue = true;
    }
    void Update()
    {
        if (canContinue)
        {
            if (Input.GetKeyDown("space"))
            {
                AdvanceConversation();
            }
        }
    }
    void AdvanceConversation()
    {
        if (LineIndex < conversation.lines.Length)
        {
            canContinue = false;
            DisplayLine();
            LineIndex += 1;
        }
        else if (Left.activeInHierarchy || Right.activeInHierarchy)
        {
           /* Enemy[] enemies =  FindObjectsOfType<Enemy>();
            foreach (Enemy E in enemies)
            {
                E.enabled = true;
            }*/

            speakerUILeft.Hide();
            speakerUIRight.Hide();
            //player.GetComponent<Player>().Dialogue();

            //FindObjectOfType<MusicManager>().ChangeToDefaultMusic();
        }
    }

    void DisplayLine()
    {
        
        Line line = conversation.lines[LineIndex];
        Character character = line.character;

        if (speakerUILeft.SpeakerIs(character))
        {
            SetDialog(speakerUILeft, speakerUIRight, line.text, line.ImageIndex, line.ImageIndexTwo, line.character.voice[line.VoiceIndex]);
        }
        else
        {
            SetDialog(speakerUIRight, speakerUILeft, line.text, line.ImageIndex, line.ImageIndexTwo, line.character.voice[line.VoiceIndex]);
        }
    }
    void SetDialog(SpeakerUI Active, SpeakerUI Inactive, string text, int imdex, int imdexTwo , AudioClip voice)
    {
        Active.Dialogue = text;
        Active.Show();
        Active.clip = voice;
        Inactive.Hide();
        Active.ConversationText(imdex, imdexTwo, voice);
    }
    public void PlaySong(AudioClip clip)
    {
        audios.clip = clip;
        audios.Play();
    }

}
