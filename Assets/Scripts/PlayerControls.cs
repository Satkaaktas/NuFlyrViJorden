using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    IInteractable currentInteractable;
    
    GameObject interactButton;

    [SerializeField]
    float moveSpeed, rotSpeed;

    float vertical, horizontal;

    //Quaternion[] moveRotations = new Quaternion[] { new Quaternion(0f, 45f, 0f)};

    void Start()
    {
        interactButton = GameObject.Find("InteractButton");
        interactButton.SetActive(false);
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.DoAction();
        }
    }

    void Move()
    {
        //ska ändras
        horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
        //transform.Translate(horizontal, 0, vertical, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        IInteractable otherInterface = other.gameObject.GetComponent<IInteractable>();
        if (otherInterface != null)
        {
            otherInterface.ShowAction(true);
            interactButton.SetActive(true);
            currentInteractable = otherInterface;
        }
    }

    void OnTriggerExit(Collider other)
    {
        IInteractable otherInterface = other.gameObject.GetComponent<IInteractable>();
        if (otherInterface != null)
        {
            otherInterface.ShowAction(false);
            interactButton.SetActive(false);
            currentInteractable = null;
        }
    }
}