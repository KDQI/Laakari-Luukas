using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;    // Tarvitaan äänen kanssa

[System.Serializable] // Näkyy Inspectorissa
public class Sound
{
    public AudioClip clip;
    public string name;

    [Range(0f, 10000f)]
    public float volume;
    [Range (0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
