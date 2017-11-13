using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

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

    void Start()
    {
        myMat = GetComponent<Renderer>().material;
        dR = GameObject.Find("DialogueManager").GetComponent<DialogueRunner>();
    }

    public void DoAction()          //Initierar en dialog mellan spelaren och NPCn
    {
        GameObject.Find("PlayerPrefab").GetComponent<PlayerControls>().CurrentInteractable = null;      
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