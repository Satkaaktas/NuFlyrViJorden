using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DaughterScript : MonoBehaviour, IInteractable
{
    [SerializeField]
    float minDistance, maxDistance;

    NavMeshAgent agent;

    PlayerControls mother;

    Vector3 offset = new Vector3(-3f, 0f, -2f);

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        mother = FindObjectOfType<PlayerControls>();
    }

    public void DoAction()
    {

    }

    public void ShowAction(bool show)
    {

    }

    void Update()
    {
        float currentDistance = Vector3.Distance(transform.position, mother.transform.position);
        if (currentDistance > minDistance && currentDistance <= maxDistance)
        {
            agent.isStopped = false;
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
            agent.SetDestination(new Vector3(mother.transform.position.x, 0f, mother.transform.position.z));
        }
        else if (currentDistance > maxDistance)
        {
            agent.isStopped = false;
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
            agent.Warp(new Vector3(mother.transform.position.x, 0f, mother.transform.position.z) + offset);
        }
        else if (currentDistance < minDistance)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
            agent.isStopped = true;
            agent.SetDestination(transform.position);
        }
    }
}
