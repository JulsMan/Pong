using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance = null;

    public AudioClip WallBounce;
    public AudioClip PaddleBounce;
    public AudioClip Goal;
    public AudioClip Lose;
    public AudioClip Win;
    public AudioClip Quit;

    private AudioSource soundEffectAudio;


    // Use this for initialization
    void Start()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }


        AudioSource[] sources = GetComponents<AudioSource>();

        foreach (AudioSource source in sources)
        {
            if (source.clip == null)
            {
                soundEffectAudio = source;

            }
        }


        

    }

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}
