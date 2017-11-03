using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll2Charmovement : MonoBehaviour {

    public float speed = 1f;

    private CharacterController characterController;

    private Vector3 forward, right;
    void Start () {
        characterController = GetComponent<CharacterController>();

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

    }
	
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 horizontal = right * h;
        Vector3 vertical = forward * v;

        Vector3 direction = Vector3.Normalize(horizontal + vertical);
        direction *= speed;

        characterController.SimpleMove(direction);

        if (direction.magnitude > .01f)
            transform.forward = direction;
        
    }


}
