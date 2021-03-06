﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    AudioSource musicSource; // GameObject.Camera.fin
    [SerializeField]
    AudioSource efxSource;

    public float musicVol;
    public float efxVol;

    private float lowPitchLimit = 0.95f;
    private float highPitchLimit = 1.05f;

    public static SoundManager instance;

    private void Awake()
    {   
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }

    // used to play single soundclips.
    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;

        efxSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    // used to play random clips at somewhat random pitch. <------------------- use for walking.
    public void PlayRandom(params AudioClip[] clips)
    {
        //chose random clip in range.
        int randomIndex = Random.Range(0, clips.Length);

        //set varied pitch of sound.
        float randomPitch = Random.Range(lowPitchLimit, highPitchLimit);

        efxSource.pitch = randomPitch;

        //play clip
        efxSource.Play();
        
    }

    // invoked when slider button is clicked.
    public void ChangeMusicVol(Slider slider)
    {
        musicSource.volume = slider.value;

    }

    // invoke when slider button is clicked
    public void ChangeEfxVol(Slider slider)
    {

    }

}

// Stina Hedman

