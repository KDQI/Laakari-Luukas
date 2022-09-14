using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;    // Ääntä varten

public class AudioManager : MonoBehaviour {
    public Sound[] sounds;

    public bool isSoundMuted = false;
    public bool isMusicMuted = false;

    public static AudioManager instance;

 

	void Awake () {

        

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

         Play("bgm");
    }

    public void Start()
    {
    }

    public void Play(string name)
    {
        if (name == "bgm")
        {
            if (!isMusicMuted)
            {
                Sound s = Array.Find(sounds, sound => sound.name == name);
                if (s == null)
                    return;
                s.source.Play();
                
            }
        }
        else if (!isSoundMuted)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
                return;
            s.source.Play();
        }
    }

    public void StopPlay(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }

    public void StopAll()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            Sound[] s = Array.FindAll(sounds, sound => sound.name.Length > 1);
            StopPlay(s[i].name);
        }
    }

}
