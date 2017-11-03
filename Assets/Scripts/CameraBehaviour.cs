using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    GameObject Player;
    PlayerControls PlayerScript;
    float x, y, z;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Char_TestMain_PF");
        PlayerScript = Player.GetComponent<PlayerControls>();
        x = transform.position.x - Player.transform.position.x;
        y = transform.position.y - Player.transform.position.y;
        z = transform.position.z - Player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector3(Player.transform.position.x + x, Player.transform.position.y + y, Player.transform.position.z + z);
    }
}
