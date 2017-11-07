using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{

    public void DoAction()
    {
        GameObject.Find("PlayerPrefab").GetComponent<PlayerControls>().CurrentInteractable = null;
        Destroy(this.gameObject);
    }

    public void ShowAction(bool show)
    {

    }
}
