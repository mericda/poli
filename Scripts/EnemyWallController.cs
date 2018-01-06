
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWallController : MonoBehaviour {




	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		

	}
		

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "Player") {
			Debug.Log("Collision!");
			Debug.Log ("Adding 1 point to score");
		
				FishController.F.KillPlayer ();

		}
	}

}