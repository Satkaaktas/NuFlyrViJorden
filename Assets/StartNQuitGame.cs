using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartNQuitGame : MonoBehaviour {

    public void startNew() //Used to load a new game.
    {
        SceneManager.LoadScene ("XXX", LoadSceneMode.Single); //TODO Change XXX to scene of game.
    }

    //TODO Add load function here.

    public void quit() //Used to quit the game.
    {
        Application.Quit(); //Doesn't work when debugging in unity.
    }
}
