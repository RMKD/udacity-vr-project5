using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumLogic : MonoBehaviour {

	GameObject obj;

	public GameObject player;
	public GameObject camera;
	public GameObject startWaypoint;
	public GameObject welcomeScreen;

	private float fixedWelcomeScreenXRotation;

	Vector3 nextPosition;
	// Use this for initialization
	void Start () {
		player = camera.transform.parent.gameObject;
		player.transform.position = startWaypoint.transform.position;
		fixedWelcomeScreenXRotation = welcomeScreen.transform.rotation.eulerAngles.x;
	}

	public void SetNextPosition(Vector3 position){
		nextPosition = position;
	}

	public void UpdatePosition(){
		iTween.MoveTo (player,
			iTween.Hash(
				"position", nextPosition, 
				"time", 2, 
				"easetype", "linear"
			)
		);
	}

	void Update () {
		RenderSettings.skybox.SetFloat("_Exposure", Mathf.Sin(Time.time * Mathf.Deg2Rad * 20)*Mathf.Sin(Time.time * Mathf.Deg2Rad * 20)/2f + 0.75f);
		RenderSettings.skybox.SetFloat("_Rotation", Time.time * .2f); 

		if (welcomeScreen.activeSelf) {
			welcomeScreen.transform.rotation = Quaternion.Euler(
				new Vector3(
					fixedWelcomeScreenXRotation, 
					camera.transform.rotation.eulerAngles.y, 
					camera.transform.rotation.eulerAngles.z
				)
			);
		}
	}
}
