using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLogic : MonoBehaviour
{
    public static SoundLogic instance;

    public Sound[] MusicSfxes, SoundSfxes;
    public AudioSource MusSource, SfxSource;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return; // важно вернуть, чтобы не подписываться на событие в уничтожаемом объекте
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        
        
    }
    private void Start()
    {
        PlayMusic("MainMusic");

    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(MusicSfxes, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Music not found");

        }
        else
        {
            
            MusSource.clip = s.clip;
            MusSource.Play();
            
        }

    }
    public void PlaySfx(string name)
    {
        Sound s = Array.Find(SoundSfxes, x => x.name == name);
        if(s == null)
        {
            Debug.Log("Sound Not Found");

        }
        else
        {
            SfxSource.PlayOneShot(s.clip);
        }
            
    }

    
}
