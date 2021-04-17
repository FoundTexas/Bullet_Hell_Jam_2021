using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    //Player[] player;
    public GameObject PauseUI;
    bool Paused;
    public Slider slider;

    void Start()
    {
        Time.timeScale = 1;
       
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKeyDown("p"))
        {
            ppause();
        }*/

    }

    public void Setslider()
    {
        slider.value = FindObjectOfType<GameManager>().volumevalue();
    }

    public void Mute()
    {
        FindObjectOfType<GameManager>().ToggleSound();
    }

    public void Changevolume()
    {
        FindObjectOfType<GameManager>().Changevolume(slider.value);
    }

    /*public void ppause()
    {
        Paused = !Paused;
        PauseUI.SetActive(Paused);
        Time.timeScale = (Paused) ? 0 : 1f;
        player = FindObjectsOfType<Player>();
        foreach (Player p in player) {
            p.enabled = !Paused;
                }
        Setslider();
    }*/

    public void EndLevel()
    {
        //ppause();
        FindObjectOfType<GameManager>().NextLevel();

    }
    public void ExitToMenu()
    {
        //ppause();
        FindObjectOfType<GameManager>().Menu();
    }
    public void ExitToPSelect()
    {
        //ppause();
        FindObjectOfType<GameManager>().Load(1);
    }
    public void ReloadScene()
    {
        //ppause();
        FindObjectOfType<GameManager>().Reload();
    }
    public void ExitToDesktop()
    {
        //ppause();
        Application.Quit();
    }
}
