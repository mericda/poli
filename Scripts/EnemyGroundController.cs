
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundController : MonoBehaviour {

	public float speed = 6.0f;
	public float gravity = 20.0f;
	private SpriteRenderer mySpriteRenderer;
	private CharacterController controller;

	private Vector3 moveDirection = Vector3.zero;

	private bool faceLeft = true;

	// Use this for initialization
	void Start () {


		controller = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {


	}




	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "Player") {
				BirdController.B.KillPlayer ();
			}
		}


}