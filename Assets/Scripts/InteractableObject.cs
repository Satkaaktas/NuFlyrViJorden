using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{

    GameObject interactionButton;

    public void DoAction()
    {
        Destroy(gameObject);
    }

    public void ShowAction(bool show)
    {
       // interactionButton.SetActive(show);
    }
}
