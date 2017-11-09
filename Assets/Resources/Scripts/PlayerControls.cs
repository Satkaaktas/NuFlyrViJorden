using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    IInteractable currentInteractable;

    GameObject interactButton;

    Animator playerAnim;

    [SerializeField]
    float speed;

    float v, h;

    bool moving = false;

    public IInteractable CurrentInteractable
    {
        get { return this.currentInteractable; }
        set
        {
            if (value == null)
            { interactButton.SetActive(false); }
            else
            { interactButton.SetActive(true); }
            this.currentInteractable = value;
        }
    }

    public bool Moving
    {
        get { return this.moving; }
    }

    private CharacterController characterController;

    private Vector3 forward, right, vertical, horizontal, direction;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
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
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        horizontal = right * h;
        vertical = forward * v;

        direction = Vector3.Normalize(horizontal + vertical);
        direction *= speed;

        characterController.SimpleMove(direction);

        if (direction.magnitude > 0.11f)
        {
            transform.forward = direction;
            moving = true;
            playerAnim.SetBool("isRunning", true);
        }
        else
        {
            moving = false;
            playerAnim.SetBool("isRunning", false);
        }
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