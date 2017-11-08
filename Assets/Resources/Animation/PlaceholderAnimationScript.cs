using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderAnimationScript : MonoBehaviour {

    Animator animator;
    Vector3 Forward;
    Vector3 Sideways;
    Vector3 Direction;
    bool walk;
	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        Forward = this.transform.forward * Input.GetAxis("Vertical");
        Sideways = this.transform.right * Input.GetAxis("Horizontal");

        Forward.y = 0;
        Sideways.y = 0;

        Direction = Vector3.Normalize(Sideways + Forward);
        this.transform.LookAt(this.transform.position + Direction);

        walk = Direction.sqrMagnitude > .01f;
        animator.SetBool("iswalking", walk);

    }
}
