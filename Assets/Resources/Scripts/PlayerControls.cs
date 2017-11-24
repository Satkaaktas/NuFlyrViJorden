using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*By Björn Andersson && Timmy Alvelöv*/
public class PlayerControls : MonoBehaviour
{
    IInteractable currentInteractable;

    GameObject interactButton;

    Animator playerAnim;

    [SerializeField]
    float speed;

    float v, h;

    bool moving = false, movementEnabled = true, inputEnabled;

    public bool InputEnabled
    {
        get { return this.inputEnabled; }
        set { this.inputEnabled = value; }
    }

    private CharacterController characterController;

    private Vector3 forward, right, vertical, horizontal, direction;

    float originalSpeed;

    public bool MovementEnabled
    {
        get { return this.movementEnabled; }
        set { this.movementEnabled = value; if (value == false) { playerAnim.SetBool("isRunning", false); } }
    }

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

    void Start()
    {
        inputEnabled = true;
        originalSpeed = speed;
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
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null && inputEnabled)         //Interagerar med föremål och NPCs när spelaren klickar på E
        {
            if (currentInteractable is InteractableObject || ((NPCScript)currentInteractable).MyDialogueNode != "null")
            {
                playerAnim.SetBool("isRunning", false);
                playerAnim.SetBool("isWalking", false);
                currentInteractable.DoAction();
            }
        }

    }

    void ResetMovement()                    //Hindrar ett fel som får spelaren att springa som en idiot efter konversationer
    {
        h = 0f;
        v = 0f;
        horizontal = Vector3.zero;
        vertical = Vector3.zero;
        direction = Vector3.zero;
    }

    void Move()                             //Sköter spelarkaraktärens rörelser och bestämmer vilken animation som ska spelas upp
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        horizontal = right * h;
        vertical = forward * v;

        direction = Vector3.Normalize(horizontal + vertical);
        direction *= speed;

        if (movementEnabled)
        {
            if (direction != Vector3.zero)
            {

                characterController.SimpleMove(direction);
            }
            if (direction.magnitude > 0.11f)
            {
                transform.forward = direction;
                moving = true;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = originalSpeed / 2;
                    playerAnim.SetBool("isRunning", false);
                    playerAnim.SetBool("isWalking", true);
                }
                else if (!Input.GetKey(KeyCode.LeftShift))
                {
                    playerAnim.SetBool("isRunning", true);
                    playerAnim.SetBool("isWalking", false);
                    speed = originalSpeed;
                }
            }
            else
            {
                moving = false;
                playerAnim.SetBool("isRunning", false);
                playerAnim.SetBool("isWalking", false);
            }
        }
    }

    void OnTriggerEnter(Collider other)                     //Möjliggör för spelaren att interagera med föremål och NPCs
    {
        IInteractable otherInterface = other.gameObject.GetComponent<IInteractable>();
        if (otherInterface != null)
        {
            otherInterface.ShowAction(true);
            interactButton.SetActive(true);
            currentInteractable = otherInterface;
        }
    }

    void OnTriggerExit(Collider other)                     //Omöjliggör för spelaren att interagera med föremål och NPCs
    {
        IInteractable otherInterface = other.gameObject.GetComponent<IInteractable>();
        if (otherInterface != null)
        {
            otherInterface.ShowAction(false);
            interactButton.SetActive(false);
            currentInteractable = null;
        }
        else
        {
            DoorScript door = other.gameObject.GetComponentInParent<DoorScript>();
            if (door != null)
            {
                door.WalkThroughDoor(other);
            }
        }
    }
}