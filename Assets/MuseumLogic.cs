using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumLogic : MonoBehaviour {

	GameObject obj;

	public GameObject player;
	public GameObject startWaypoint;
	Vector3 nextPosition;
	// Use this for initialization
	void Start () {
		player = player.transform.parent.gameObject;
		player.transform.position = startWaypoint.transform.position;
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
	}
}
