using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                                                    /*By Björn Andersson*/
public class MiniMapCamScript : MonoBehaviour
{
    void Start()
    {
        transform.Rotate(transform.rotation.x, -27f, transform.rotation.z, Space.World);            //Gör så att minimapkameran har korrekt rotation
    }
}
