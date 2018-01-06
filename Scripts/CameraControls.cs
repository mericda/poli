using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

	public GameObject player;

	private float xVelocity = 0.0f;
	private float yVelocity = 0.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		Vector3 playerposition = player.transform.position;
		Vector3 cameraposition = transform.position;

		// check for advancing camera

		if (cameraposition.x < playerposition.x) {

			cameraposition.x = Mathf.SmoothDamp (cameraposition.x, playerposition.x, ref xVelocity, 0.3f);
			transform.position = cameraposition;

		}


		if (cameraposition.x > playerposition.x) {

			cameraposition.x = Mathf.SmoothDamp (cameraposition.x, playerposition.x, ref xVelocity, -0.3f);
			transform.position = cameraposition;

		}

		if (cameraposition.y < playerposition.y) {

			cameraposition.y = Mathf.SmoothDamp (cameraposition.y, playerposition.y, ref yVelocity, 0.3f);
			transform.position = cameraposition;

		}


		if (cameraposition.y > playerposition.y) {

			cameraposition.y = Mathf.SmoothDamp (cameraposition.y, playerposition.y, ref yVelocity, -0.3f);
			transform.position = cameraposition;

		}

	}
}