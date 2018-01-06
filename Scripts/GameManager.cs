using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Text ReadyText;
	public Text LoseLifeText;
	public Text WinnerText;
	public GameObject RestartButton;
	public GameObject MenuButton;
	public int score = 5;
	public static GameManager M;

	// Use this for initialization
	void Start () {

	
		RestartButton.SetActive(false);
		MenuButton.SetActive(false);

		ReadyText.GetComponent<Text> ().enabled = false;
		LoseLifeText.GetComponent<Text>().enabled = false;

		WinnerText.GetComponent<Text> ().enabled = false;

		// check for the singleton
		if (GameManager.M != null) {
			// singleton already exists.  destroy this object and cease execution of script
			Destroy (this.gameObject);
			return;
		}

		// We only arrive here if no singleton has been set, so now we define it.
		M = this;
		//DontDestroyOnLoad (this);


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Debug.Log ("Restart!");
			buttonscript.BU.GoToMainMenu ();
		}

			
	}


	public IEnumerator ReadyBlink() {
		for (int i = 0; i < 3; i++) {
			
			ReadyText.GetComponent<Text> ().enabled = true;
			yield return new WaitForSeconds (0.5f);
		

			ReadyText.GetComponent<Text> ().enabled = false;
			yield return new WaitForSeconds (0.5f);

		}

	}



	public void LoseALife() {
		score -= 1;
	}

}
