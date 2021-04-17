using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Selection_UI_Manager : MonoBehaviour
{
    int nivelActual;
    [SerializeField] Image miniatura;
    [SerializeField] Text text;
    [SerializeField] GameObject[] levels;
    int reachedLevel;

    public void Displaylevels()
    {
        reachedLevel = PlayerPrefs.GetInt("1");
        if(reachedLevel < PlayerPrefs.GetInt("2"))
        {
            reachedLevel = PlayerPrefs.GetInt("2");
        }
        if (reachedLevel < PlayerPrefs.GetInt("3"))
        {
            reachedLevel = PlayerPrefs.GetInt("3");
        }

        foreach (var lv in levels)
        {
            lv.SetActive(false);
        }
        for(int i = 0; i <reachedLevel-1; i++)
        {
            levels[i].SetActive(true);
        }
        
        //nivelActual = FindObjectOfType<GameManager>().
    }

    public void SetLevelUI(Sprite min, string desc, int n)
    {
        miniatura.sprite = min;
        text.text = desc;
        nivelActual = n;
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene(nivelActual);
    }
}
