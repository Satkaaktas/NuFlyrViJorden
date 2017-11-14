using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource musicSource; // GameObject.Camera.fin
    public AudioSource efxSource;

    public float lowPitchLimit = 0.95f;
    public float highPitchLimit = 1.05f;

    public static SoundManager instance;

    private void Awake()
    {   
        //kolla om en instans av soundmanager redan är i scenen.
        if (instance == null)
        {
            instance = this;
        }

        //ser till att det bara är en soundmanager instansierad.
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // used to play single soundclips.
    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;

        efxSource.Play();
    }

    // used to play random clip at somewhat random pitch. <------------------- use for walking.
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

    private void Start()
    {
        
    }


}

