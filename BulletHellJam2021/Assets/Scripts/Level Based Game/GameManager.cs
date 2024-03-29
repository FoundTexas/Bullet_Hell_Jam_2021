﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Animator anim;
    public float TransitionTime = 1f;
    bool NotLs;
    string curS;

    private static GameManager gameManager;
    public int MaxLevels = 5;

    public float X;
    public float Y;
    public int Objs;

    public Sound[] Level;

    public Sound Deadsound, menu, myst, end, otherClip;

    AudioSource audios;

    bool b;
    public bool toggle = true;

    // Use this for initializationz
    void Awake()
    {
        //anim = GameObject.FindGameObjectWithTag("Fader").GetComponent<Animator>();
        if (gameManager == null)
        {
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    public void ToggleSound()
    {
        toggle = !toggle;

        if (toggle)
            AudioListener.volume = 1f;

        else
            AudioListener.volume = 0f;
    }

    public float volumevalue()
    {
        Debug.Log(AudioListener.volume);
        return AudioListener.volume + 0f;
    }

    public void Changevolume(float val)
    {
        AudioListener.volume = val;
        if ( val <= 0)
        {
            toggle = false;
        }
        else if (val > 0)
        {
            toggle = true;
        }
    }

    private void Start()
    {
        audios = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("1") == false)
        {
            PlayerPrefs.SetInt("1", 0);
        }
        if (PlayerPrefs.HasKey("2") == false)
        {
            PlayerPrefs.SetInt("2", 0);
        }
        if (PlayerPrefs.HasKey("3") == false)
        {
            PlayerPrefs.SetInt("3", 0);
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            audios.clip = menu.clip;
            audios.volume = menu.volume;
            audios.loop = true;
            audios.Play();
        }
        b = false;
    }
    void Update()
    {
        if (!audios.isPlaying)
        {
            audios.clip = otherClip.clip;
            audios.volume = otherClip.volume;
            audios.loop = true;
            audios.PlayDelayed(-1);
        }

    }

    public void StartGame(string s)
    {
        curS = s;
        
        if (PlayerPrefs.HasKey(curS) && PlayerPrefs.GetInt(curS) > 0 && PlayerPrefs.GetInt(curS) <= MaxLevels)
        {
            Load(PlayerPrefs.GetInt(curS));
            return;
        }
        else if (PlayerPrefs.GetInt(curS) > MaxLevels)
        {
            Load(PlayerPrefs.GetInt(curS) - 1);
            return;
        }
        else
        {
            //SaveGame();
            Load(1);
            return;
        }
    }

    public void NextLevel()
    {

        Debug.Log("enternext");
        if (SceneManager.GetActiveScene().buildIndex < MaxLevels)
        {
            SaveGame(1);
            Debug.Log("1");
            Load(SceneManager.GetActiveScene().buildIndex + 1);
            audios.clip = Level[SceneManager.GetActiveScene().buildIndex].clip;
            audios.volume = Level[SceneManager.GetActiveScene().buildIndex].volume;
            audios.Play();
        }
        else if (SceneManager.GetActiveScene().buildIndex >= MaxLevels)
        {
            SaveGame(0);
            audios.clip = menu.clip;
            audios.volume = menu.volume;
            audios.Play();
            Debug.Log("2");
            Load(0);
        }
    }

    public void Dead()
    {
        if (!b)
        {
            b = true;
            anim = GameObject.FindGameObjectWithTag("Fader").GetComponent<Animator>();
            //audios.clip = Deadsound;
            //audios.Play();
            StartCoroutine(Playdead());
        }
    }

    IEnumerator Playdead()
    {
        Debug.Log("pre");
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        Load(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        
        X = 0;
        Y = 0;
        Load(0);
    }
    public void Reload()
    {
        Load(SceneManager.GetActiveScene().buildIndex);
    }

    public void Load(int index)
    {
        
        anim = GameObject.FindGameObjectWithTag("Fader").GetComponent<Animator>();
        StartCoroutine(loadLevel(index));
    }
    IEnumerator loadLevel(int i)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);
        if (i > 0)
        {
            audios.clip = Level[i].clip;
            audios.volume = Level[i].volume;
            audios.loop = false;
            audios.Play();
            
        }
        else
        {
            audios.clip = menu.clip;
            audios.volume = menu.volume;
            audios.loop = true;
            audios.Play();
        }
        b = false;
        SceneManager.LoadScene(i);
    }

    public void ResetGame(int s)
    {
        PlayerPrefs.SetInt(s + "", 0);
    }

    public void SaveGame(int i)
    {
        PlayerPrefs.SetInt(curS, SceneManager.GetActiveScene().buildIndex + i);
    }

    public bool anyComplete()
    {
        NotLs = false;
        return (PlayerPrefs.GetInt("1") >= MaxLevels || PlayerPrefs.GetInt("2") >= MaxLevels || PlayerPrefs.GetInt("3") >= MaxLevels);
    }
    public void EndSong()
    {
        audios.clip = end.clip;
        audios.volume = end.volume;
        audios.loop = false;
        audios.Play();
    }

}

