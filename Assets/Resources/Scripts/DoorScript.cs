using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    [SerializeField]
    Collider inColl, outColl;

    [SerializeField]
    GameObject[] wallsAndRoof;

    [SerializeField]
    float fadeAlpha;
	
    public void WalkThroughDoor(Collider inOut)
    {
        if (inOut == inColl)
        {
            ShowWalls(fadeAlpha);
        }
        else if (inOut == outColl)
        {
            ShowWalls(1f);
        }
        else
        {
            print("nu har nåt gått fel här.");
        }
    }

    void ShowWalls(float alpha)
    {
        foreach (GameObject wall in wallsAndRoof)
        {
            Color newColor = wall.GetComponent<Renderer>().material.color;
            newColor.a = alpha;
            wall.GetComponent<Renderer>().material.color = newColor;
        }
    }
}
