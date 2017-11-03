using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    IInteractable currentInteractable;

    CharacterController cc;

    [SerializeField]
    float moveSpeed, rotSpeed;

    float vertical, horizontal;

    void Start()
    {
        cc = GetComponent<CharacterController>();
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
        horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * rotSpeed;
        transform.Rotate(0, horizontal, 0, Space.Self);
        vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(0, 0, vertical, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        IInteractable otherInterface = other.gameObject.GetComponent<IInteractable>();
        if (otherInterface != null)
        {
            otherInterface.ShowAction(true);
            currentInteractable = otherInterface;
        }
    }

    void OnTriggerExit(Collider other)
    {
        IInteractable otherInterface = other.gameObject.GetComponent<IInteractable>();
        if (otherInterface != null)
        {
            otherInterface.ShowAction(false);
            currentInteractable = null;
        }
    }
}