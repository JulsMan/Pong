using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance = null;
    public AudioSource musicSource;
    public AudioSource soundEffectAudio;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;


    public AudioClip WallBounce;
    public AudioClip PaddleBounce;
    public AudioClip Goal;
    public AudioClip Lose;
    public AudioClip Win;
    public AudioClip Quit;

    


    // Use this for initialization
    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);


        AudioSource[] sources = GetComponents<AudioSource>();

        foreach (AudioSource source in sources)
        {
            if (source.clip == null)
            {
                Debug.Log(source.clip.name);

                soundEffectAudio = source;

            }
        }


        

    }

    public void PlayOneShot(AudioClip clip)
    {
        Debug.Assert(clip == null, "clip is null");
        Debug.Assert(soundEffectAudio == null, "soundEffectAudio is null");

        soundEffectAudio.clip = clip;
        soundEffectAudio.Play();
    }


    public void RadmonizeSfx(params AudioClip[] clips)
    {
        int randomINdex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        soundEffectAudio.pitch = randomPitch;
        soundEffectAudio.clip = clips[randomINdex];
        soundEffectAudio.Play();
    }
}
