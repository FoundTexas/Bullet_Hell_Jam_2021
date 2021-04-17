using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public string Name;
    public float Puntuacion;
    public string Descripcion;
    public Sprite Miniatura;
    public int index;

    //Metod of accesing

    //Ui touch
    public void SendLevel()
    {
        string desc = "Name: " + Name + "\n\nScore:" + Puntuacion +"\n\nDescription: " + Descripcion;
        FindObjectOfType<Level_Selection_UI_Manager>().SetLevelUI(Miniatura, desc, index);
    }
}
