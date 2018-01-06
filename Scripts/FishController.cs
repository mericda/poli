using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private SpriteRenderer herosprite;
	private bool faceRight = true;

	private Vector3 moveDirection = Vector3.zero;

	private CharacterController controller;
	private Animator Animator; 
	public float leftSideOffset;
	private bool stillAlive = true;

	static public FishController F;


	private GameObject gameCamera;

	void Start() {
		F = this;
		controller = GetComponent<CharacterController>();
		herosprite = GetComponent<SpriteRenderer>();
		Animator = GetComponent<Animator>();
		gameCamera = GameObject.FindGameObjectWithTag ("MainCamera");

	}

	void Update() {

		if (GameManager.M.score == 0) {
			LoseGame ();
		}

		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		moveDirection *= speed;
		moveDirection.x += Input.GetAxis ("Horizontal") * 1f;
		moveDirection.y += Input.GetAxis ("Vertical") * 1f;
		moveDirection.x = Mathf.Clamp (moveDirection.x, -speed, speed);
		moveDirection.y = Mathf.Clamp (moveDirection.y, -speed, speed);


		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);


		Vector3 checkposition = transform.position;
		float leftx = gameCamera.transform.position.x - leftSideOffset;

		if (checkposition.x < leftx) {
			checkposition.x = leftx;

			transform.position = checkposition;
		}

		if (Input.GetKeyDown (KeyCode.Q)) {

			stillAlive = !stillAlive;
			Debug.Log (stillAlive);
			Debug.Log ("Restart!");
			GameManager.M.LoseALife ();

			StartCoroutine(MyCoroutine());
		}

		Animator.SetFloat ("speed", Mathf.Abs(Input.GetAxis ("Horizontal")));

		Animator.SetBool("alive", stillAlive);

		if ((Input.GetAxis ("Horizontal") < 0) && faceRight) {
			herosprite.flipX = true;
			faceRight = false;
		} else if ((Input.GetAxis ("Horizontal") > 0) && !faceRight) {
			faceRight = true;
			herosprite.flipX = false;
		}


	}
	IEnumerator MyCoroutine()
	{
		controller.enabled = true;
		//disable the desired script here
		yield return new WaitForSeconds(3F);
		//enable it here
		controller.enabled = true;


	}



			
	

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.gameObject.tag == "Platform") {
			Debug.Log("Collision!");

			KillPlayer ();
		}
		if (hit.gameObject.tag == "mother") {
			Debug.Log("Win!");

			WinLevel ();
		}
	}

	public void BouncePlayer() {
		moveDirection.y = 5.0f;
	}


	public void LoseGame () {
		GameManager.M.LoseLifeText.enabled = true;

		stillAlive = false;
		controller.enabled = false;
		GameManager.M.RestartButton.SetActive(true);
		SoundManager.SM.MakeDeathSound ();

	}

	public void KillPlayer () {

		stillAlive = false;
		controller.enabled = false;
		StartCoroutine(GameManager.M.ReadyBlink());
		SoundManager.SM.MakeLiveSound ();

	}
	public void WinLevel() {
		stillAlive = true;
		controller.enabled = false;
		GameManager.M.WinnerText.enabled = true;
		GameManager.M.MenuButton.SetActive(true);
		SoundManager.SM.MakeWinSound ();

	}

}