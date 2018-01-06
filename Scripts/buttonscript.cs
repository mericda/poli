using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonscript : MonoBehaviour {
	static public buttonscript BU;

	public void GoToLevel1() {
		SoundManager.SM.MakeButtonSound ();
		SceneManager.LoadScene ("poli1");
	}

	public void GoToLevel2() {
		SoundManager.SM.MakeButtonSound ();
		SceneManager.LoadScene ("poli2");
	}

	public void GoToLevel3() {
		SoundManager.SM.MakeButtonSound ();
		SceneManager.LoadScene ("poli3");
	}


	public void GoToMainMenu() {
		SoundManager.SM.MakeButtonSound ();
		SceneManager.LoadScene ("Main Menu");
	}

	public void TryAgain3() {
		SoundManager.SM.MakeButtonSound ();
		SceneManager.LoadScene ("poli3");
	}

	public void Add1Point() {
		SoundManager.SM.MakeButtonSound ();
		Debug.Log ("Adding 1 point to score");
		GameManager.M.LoseALife ();
	}

	void Start() {
		BU = this;
	}
		
}
