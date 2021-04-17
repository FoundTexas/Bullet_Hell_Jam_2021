using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSelect_UI_Manager : MonoBehaviour
{
    GameManager GM;
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    public void StartGame(string s)
    {
        GM.StartGame(s);
    }

    public void ResetGame(int s)
    {
        GM.ResetGame(s);
    }
}
