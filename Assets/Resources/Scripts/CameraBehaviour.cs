using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed, waitToFollow;

    GameObject player;
    PlayerControls playerScript;
    float x, y, z;

    bool following = false, waiting = false;

    void Start()
    {
        player = GameObject.Find("Template_Female_Mesh_3");
        playerScript = player.GetComponent<PlayerControls>();
        x = transform.position.x - player.transform.position.x;
        y = transform.position.y - player.transform.position.y;
        z = transform.position.z - player.transform.position.z;
    }

    void LateUpdate()
    {
        if (!following && !waiting && playerScript.Moving)
        {
            StartCoroutine("FollowWait");
        }
        else if (following && !waiting)
        {
            Vector3 targetPos = new Vector3(player.transform.position.x + x, player.transform.position.y + y, player.transform.position.z + z);
            transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, speed);
            if (Vector3.Distance(transform.position, targetPos) < 0.2f)
            {
                following = false;
            }
        }
    }

    IEnumerator FollowWait()
    {
        waiting = true;
        yield return new WaitForSeconds(waitToFollow);
        following = true;
        waiting = false;
    }
}
