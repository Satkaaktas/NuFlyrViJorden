using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCredits : MonoBehaviour {
    public GameObject mMenu;
    float timeLeft = 30.0f;
    float setvol = 1; // Change to volume set in the settings menu.
    AudioSource m_MyAudioSource;
    
    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.volume = setvol; // Returns 1 for now, could be unessasary.
    }
        void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1)) //Force end credits
        {
            this.gameObject.SetActive(false);
            mMenu.gameObject.SetActive(true);
            resatCredits();
        }
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0) //End the credits in time.
            {
                this.gameObject.SetActive(false);
                mMenu.gameObject.SetActive(true);
                resatCredits();
            }
        if (timeLeft < 5 && timeLeft > 0) // Start fading.
        {
            float fade = 0.004f;
            //float xD = 0.1f;
            this.GetComponentInChildren<CanvasGroup>().alpha -= fade;
            m_MyAudioSource.volume -= fade/2;
        }

    }
    void resatCredits()
    {
        timeLeft = 30.0f;
        this.GetComponentInChildren<CanvasGroup>().alpha = 1;
        m_MyAudioSource.volume = setvol;
    }
}
