using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour {

	public MuseumLogic controller;

	public AudioSource description;
	public AudioSource credits;

	void Start(){

	}

	public void BringPlayer(){
		controller.SetNextPosition (transform.position);
		controller.UpdatePosition ();
		PlayDescription ();
	}

	public void PlayDescription(){
		description.Play ();
	}

	public void PlayCredits(){
		description.Stop ();
		credits.Play ();
	}

	public void StopAudio(){
		description.Stop ();
		credits.Stop ();
	}
}
