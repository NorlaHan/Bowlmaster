using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	private BowlingBall bowlingBall;
	private Vector3 offSet;

	// Use this for initialization
	void Start () {
		bowlingBall = GameObject.FindObjectOfType<BowlingBall> ();
		offSet = transform.position - bowlingBall.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (bowlingBall.transform.position.z <= 1800f) {
			transform.position = bowlingBall.transform.position + offSet;
		}
		
	}
}
