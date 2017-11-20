﻿/*
 * Skapad av: Andres Ramiréz
 * 2017-11-13 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public Transform canvas;

    PlayerControls player;

    void Start()
    {
        player = FindObjectOfType<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // If sats som kollar ifall man trycker på ESC för att pause
        {
            Pausing();
        }
    }

    public void Pausing()
    {

        if (canvas.gameObject.activeInHierarchy == false) // Kollar om Gameobject inte är aktiv i scenen.
        {
            player.InputEnabled = false;
            canvas.gameObject.SetActive(true); // I sånnafall, gör den true så man ser paus menyn och samt
            Time.timeScale = 0;                // så sätter vi skalan där tiden passerar till 0 så allt stannar i bakgrunden
        }
        else
        {
            player.InputEnabled = true;
            canvas.gameObject.SetActive(false); // När vi återgår till spelet som kan ske via att man trycker ESC igen eller Resume knappen
            Time.timeScale = 1;                 // så återgår vi till spelet, canvas blir false igen och tids skalan återgår till normalt.
        }


    }
}
