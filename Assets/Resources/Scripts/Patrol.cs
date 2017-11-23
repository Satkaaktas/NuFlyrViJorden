using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Lånad från https://docs.unity3d.com/Manual/nav-AgentPatrol.html

public class Patrol : MonoBehaviour
{
    [SerializeField]
    Transform[] points;

    private int destPoint = 0;
    private NavMeshAgent agent;

    public Transform[] Points
    {
        get { return this.points; }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(points.Length < 0)
        {
            GetComponent<NPCScript>().Anim.SetBool("isWalking", false);
        }
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length < 1)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}