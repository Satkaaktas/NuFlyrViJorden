using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.AI;

/*By Björn Andersson && Timmy Alvelöv*/

public interface IInteractable              //Ser till att spelaren kan interagera med både föremål och NPCs via samma interface
{
    void DoAction();
    void ShowAction(bool show);
}

public class NPCScript : MonoBehaviour, IInteractable
{
    GameObject interactionButton;

    Material myMat;

    [SerializeField]
    string myDialogueNode;

    [SerializeField]
    Material highlightMat;

    DialogueRunner dR;

    NavMeshAgent agent;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        myMat = GetComponent<Renderer>().material;
        if (agent.destination != null)
        {
            anim.SetBool("isWalking", true);
        }
        dR = FindObjectOfType<DialogueRunner>();
    }

    public void DoAction()          //Initierar en dialog mellan spelaren och NPCn
    {
        anim.SetBool("isWalking", false);
        FindObjectOfType<DialogueRunner>().CurrentAgent = GetComponent<NavMeshAgent>();
        if (!agent.isStopped)
        {
            agent.isStopped = true;
        }
        FindObjectOfType<PlayerControls>().CurrentInteractable = null;
        dR.SetDialogue(myDialogueNode);
    }

    public void ShowAction(bool show)       //Visar att NPCn går att interagera med
    {
        if (show)
            GetComponent<Renderer>().material = highlightMat;
        else
            GetComponent<Renderer>().material = myMat;
    }
}