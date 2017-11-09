using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed, waitToFollow;

    [SerializeField]
    GameObject player;

    PlayerControls playerScript;

    Vector3 offset;

    bool following = false, waiting = false;

    void Start()
    {
        playerScript = player.GetComponent<PlayerControls>();

        offset = new Vector3(18.6f, 24.4f, -32.7f);
        transform.position = player.transform.position + offset;
    }

    void LateUpdate()
    {
        if (!following && !waiting && playerScript.Moving)
        {
            StartCoroutine("FollowWait");
        }
        else if (following && !waiting)
        {

            Vector3 targetPos = player.transform.position + offset;
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
