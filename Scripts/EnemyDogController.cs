
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDogController : MonoBehaviour {

	public float speed = 6.0f;
	public float gravity = 20.0f;
	private SpriteRenderer mySpriteRenderer;
	private CharacterController controller;

	private Vector3 moveDirection = Vector3.zero;
	private Animator Animator; 

	private bool faceLeft = true;

	// Use this for initialization
	void Start () {
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		Animator = GetComponent<Animator>();

		controller = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {
		if (faceLeft) {
			moveDirection.x = -speed;
		} else {
			moveDirection.x = speed;
		}

		if (controller.isGrounded) {
			moveDirection.y = 0;
		}


		Animator.SetBool("grounded", controller.isGrounded);
		//Animator.SetFloat ("speed", Mathf.Abs(Input.GetAxis ("Horizontal")));

	


		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

	}



	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "TurnAround") {
			faceLeft = !faceLeft;
			mySpriteRenderer.flipX = false;
		}
		if (col.gameObject.tag == "TurnAroundRight") {
			faceLeft = !faceLeft;
			mySpriteRenderer.flipX = true;
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "Player") {
			if (hit.normal.y < -0.7f) {
				KillMe ();
			} else {
				PlayerController.S.KillPlayer ();
			}
		}
	}
	void KillMe() {
		controller.enabled = false;
		Destroy (this.gameObject);
		PlayerController.S.BouncePlayer ();
	}
}