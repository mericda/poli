using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager SM;

	public GameObject liveobj;
	public GameObject jumpobj;
	public GameObject deathobj;
	public GameObject winobj;
	public GameObject buttonobj;


	private AudioSource livesound;
	private AudioSource jumpsound;
	private AudioSource deathsound;
	private AudioSource winSound;
	private AudioSource buttonSound;


	private float pitchAdjust;

	// Use this for initialization
	void Start () {
		// assign the singleton
		SM = this;


		livesound = liveobj.GetComponent<AudioSource> ();
		jumpsound = jumpobj.GetComponent<AudioSource> ();
		deathsound = deathobj.GetComponent<AudioSource> ();
		winSound = winobj.GetComponent<AudioSource> ();
		buttonSound = buttonobj.GetComponent<AudioSource> ();

	}

	public void MakeLiveSound() {
		livesound.Play ();
	}

	public void MakeJumpSound() {
		jumpsound.Play ();
	}

	public void MakeDeathSound() {
		deathsound.Play ();
	}

	public void MakeWinSound() {
		winSound.Play ();
	}
	public void MakeButtonSound() {
		buttonSound.Play ();
	}
}
