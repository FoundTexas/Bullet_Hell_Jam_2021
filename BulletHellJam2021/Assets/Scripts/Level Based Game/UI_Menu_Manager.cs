using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Menu_Manager : MonoBehaviour
{
    bool canSelectLevel;
    [SerializeField] Button Unlockables;
    [SerializeField] bool LevelsLocked;

    public Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        //If level selectión is unlocked else comment or delete and set to true
        if (LevelsLocked)
        {
            CheckStorycompleated();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CheckStorycompleated()
    {
        if (LevelsLocked)
        {
            canSelectLevel = FindObjectOfType<GameManager>().anyComplete();
            Unlockables.interactable = canSelectLevel;
        }
    }

    public void SetLang(int i)
    {
        PlayerPrefs.SetInt("lang", i);
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
}
