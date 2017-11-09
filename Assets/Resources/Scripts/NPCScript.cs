using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public interface IInteractable
{
    void DoAction();
    void ShowAction(bool show);
}

public class NPCScript : MonoBehaviour, IInteractable {

    GameObject interactionButton;

    [SerializeField]
    TextAsset dialogue;

    DialogueRunner dR;

    void Start()
    {
        dR = GameObject.Find("DialogueManager").GetComponent<DialogueRunner>();
    }

    public void DoAction()
    {
        GameObject.Find("PlayerPrefab").GetComponent<PlayerControls>().CurrentInteractable = null;
        //dR.sourceText = this.dialogue;
        dR.StartDialogue();
    }

    public void ShowAction(bool show)
    {
        //interactionButton.SetActive(show);
    }
}
