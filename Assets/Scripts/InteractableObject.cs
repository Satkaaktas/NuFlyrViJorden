using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{

    public void DoAction()
    {
        GameObject.Find("InteractButton").SetActive(false);
        Destroy(gameObject);
    }

    public void ShowAction(bool show)
    {

    }
}
