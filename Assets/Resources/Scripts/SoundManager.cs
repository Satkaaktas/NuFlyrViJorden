using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    private AudioSource musicSource; // GameObject.Camera.fin
    private AudioSource efxSource;

    private Slider PauseMscVolSlider;
    private Slider PauseEfxVolSlicer;
    private Slider MainMscSlider;
    private Slider MainEfxVolSlider;

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
        //REFERENS TILL SLIDER 1 <-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //REFERENS TILL SLIDER 2 <-----------------------------------------------------------------------------------------------------------------------------------------------------------
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

        PauseMscVolSlider.value = musicSource.volume;
        MainMscSlider.value = musicSource.volume;
    }

    // invoke when slider button is clicked
    public void ChangeEfxVol(Slider slider)
    {
        efxSource.volume = slider.value;

        PauseEfxVolSlicer.value = efxSource.volume;
        MainEfxVolSlider.value = efxSource.volume;
    }

}

// Stina Hedman

