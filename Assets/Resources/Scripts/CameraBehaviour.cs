using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*By Björn Andersson && Timmy Alvelöv*/
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

        offset = new Vector3(18.6f, 24.4f, -32.7f);         //Håller kameran fokuserad på spelaren
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
            transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, speed);             //Följer efter spelaren utan att hinna ikapp direkt
            if (Vector3.Distance(transform.position, targetPos) < 0.2f)
            {
                following = false;
            }
        }
    }

    public void SetFollow()
    {
        transform.position = player.transform.position + offset;
    }

    IEnumerator FollowWait()           //Väntar en stund innan den börjar följa spelaren
    {
        waiting = true;
        yield return new WaitForSeconds(waitToFollow);
        following = true;
        waiting = false;
    }
}
