using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Destroy(this.gameObject);
    }

    public void ShowAction(bool show)
    {
        //interactionButton.SetActive(show);
    }
}
