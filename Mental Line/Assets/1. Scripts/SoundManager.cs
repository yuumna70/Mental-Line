using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{


    public AudioSource[] BGM;
    public AudioSource[] SFX;

    GameObject BackgroundMusic;
    AudioSource backmusic;

    

    void Awake()
    {
        BackgroundMusic = GameObject.Find("HomeBGM");
        backmusic = BackgroundMusic.GetComponent<AudioSource>();
        if (backmusic.isPlaying) return; 
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(BackgroundMusic); 
        }

        
    }

    private void Start()
    {

        for (int i = 0; i < BGM.Length; i++)
        {
            BGM[i].dopplerLevel = 0.0f;
        }
        for (int i = 0; i < SFX.Length; i++)
        {
            SFX[i].dopplerLevel = 0.0f;
        }
    }

    private void Update()
    {
        

        if(PlayerPrefs.GetInt("sound") == 1)
        {
            for (int i = 0; i < BGM.Length; i++)
            {
                BGM[i].volume = 0.5f;
                //backmusic.Play();
            }
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            for (int i = 0; i < BGM.Length; i++)
            {
                BGM[i].volume = 0.0f;
            }
        }

        if (PlayerPrefs.GetInt("sfx") == 1)
        {
            for (int i = 0; i < SFX.Length; i++)
            {
                SFX[i].volume = 0.5f;
            }
        }
        else if (PlayerPrefs.GetInt("sfx") == 0)
        {
            for (int i = 0; i < SFX.Length; i++)
            {
                SFX[i].volume = 0.0f;
            }
        }


        // 홈 사운드 0 1 11 12
        for (int i = 2; i < 11; i++)
        {
            if (SceneManager.GetActiveScene().buildIndex == i)
            {
                backmusic.mute = true;
                backmusic.time = 0f;
            }
        }
        for (int i = 13; i < 18; i++)
        {
            if (SceneManager.GetActiveScene().buildIndex == i)
            {
                backmusic.mute = true;
                backmusic.time = 0f;
            }
        }
        for (int i = 0; i < 2; i++)
        {
            if (SceneManager.GetActiveScene().buildIndex == i)
            {
                if(PlayerPrefs.GetInt("sound") == 1)
                {
                    backmusic.mute = false;
                    backmusic.volume = 0.5f;
                }
            }
        }
        for (int i = 11; i < 13; i++)
        {
            if (SceneManager.GetActiveScene().buildIndex == i)
            {
                if (PlayerPrefs.GetInt("sound") == 1)
                {
                    backmusic.mute = false;
                    backmusic.volume = 0.5f;
                }
            }
        }



    }
    public void HomeBGM()
    {
        PlayerPrefs.SetInt("sound",1);
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            backmusic.mute = false;
            backmusic.volume = 0.5f;
            backmusic.time = 0f;
        }
       
    }
    public void HomeBGMOff()
    {
        backmusic.mute = true;
    }

}