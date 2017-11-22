using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                                                                        /*By Björn Andersson && Timmy Alvelöv*/

public class DoorScript : MonoBehaviour {

    [SerializeField]
    Collider inColl, outColl;

    [SerializeField]
    GameObject walls, roof; // Väggar och tak som ska påverkas när man går in/ut i/ur dörren.

    Color[] originalColors;

    Material mat;           //Tempvariabel
    Color tempColor;
    int childs;

    [SerializeField]
    SaveLoad saveLoad;

    public bool inBool;

    void Start()
    {
        childs = walls.transform.childCount;
        originalColors = new Color[childs];
        for (int i = 0; i < childs; i++)
        {
            originalColors[i] = walls.transform.GetChild(i).GetComponent<Renderer>().material.color;
        }
    }
    public void WalkThroughDoor(Collider inOut)
    {
        if (inOut == inColl)
        {
            roof.SetActive(false);
            ShowWalls(false);
            inBool = true;
        }
        else if (inOut == outColl)
        {
            roof.SetActive(true);
            ShowWalls(true);
            inBool = false;
        }
        else
        {
            print("nu har nåt gått fel här.");
        }
    }

    public void WalkThroughDoor(bool inBool)
    {
        if (inBool)
        {
            WalkThroughDoor(inColl);
        }
        else
        {
            WalkThroughDoor(outColl);
        }
    }

    void ShowWalls(bool showWalls)         //Gömmer och visar väggar när spelaren går in och ut ur hus
    {
        
        if (showWalls)
        {
            for (int i = 0; i< childs;i++)
            {
                mat = walls.transform.GetChild(i).GetComponent<Renderer>().material;
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);     //Härifrån...
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                mat.SetInt("_ZWrite", 1);
                mat.DisableKeyword("_ALPHATEST_ON");
                mat.DisableKeyword("_ALPHABLEND_ON");
                mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                mat.renderQueue = -1;                                                  //... till hit är hämtat från internet, detta är var som händer när man ändrar renderering mode till Opaque 

                mat.color = originalColors[i];
            }
        }
        else
        {
            for (int i = 0; i < childs; i++)
            {
                mat = walls.transform.GetChild(i).GetComponent<Renderer>().material;
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);  //Härifrån...
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                mat.SetInt("_ZWrite", 0);
                mat.DisableKeyword("_ALPHATEST_ON");
                mat.DisableKeyword("_ALPHABLEND_ON");
                mat.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                mat.renderQueue = 3000;                                                 //... till hit är hämtat från internet, detta är var som händer när man ändrar renderering mode till Transparent

                tempColor.a = 0.2f;
                mat.color = tempColor;
                
            }
            
        }
    }
}
