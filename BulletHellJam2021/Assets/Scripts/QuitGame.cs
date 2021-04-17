using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour
{

    public KeyCode key = KeyCode.Escape;

    void Update()
    {
        if (Input.GetKeyDown(key)) Application.Quit();
    }

    public void QGame()
    {
        Application.Quit();
    }
}