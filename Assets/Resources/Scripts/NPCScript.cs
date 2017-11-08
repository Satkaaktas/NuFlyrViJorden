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

    public void DoAction()
    {
        GameObject.Find("PlayerPrefab").GetComponent<PlayerControls>().CurrentInteractable = null;
        //Destroy(this.gameObject);
        GameObject.Find("DialogueManager").GetComponent<DialogueRunner>().StartDialogue();
    }

    public void ShowAction(bool show)
    {
        //interactionButton.SetActive(show);
    }
}
