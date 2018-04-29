using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour {
	
	public float launchSpeed = 800f, ballRadius=10.8f, testDelay = 2f, minX, maxX;
	public Vector3 launchVector = new Vector3 (0f, 0f, 920f);

	private DragLaunch dragLaunch;
	private Vector3 startPos, startRot;
	private Rigidbody rigidBody;
	private AudioSource rollingSound;
	//private float rollSpeed;

	//private float offSetX;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		startRot = transform.rotation.eulerAngles;
		rigidBody = GetComponent<Rigidbody> ();
		// Caculate rotation
		//rollSpeed = launchSpeed / (2*ballRadius*3.14f) * -360f;
		rollingSound = GetComponent<AudioSource> ();
		//rigidBody.useGravity = false;

		if (GameObject.FindObjectOfType<DragLaunch> ()) {
			dragLaunch = GameObject.FindObjectOfType<DragLaunch> ();
		} else {Debug.LogWarning ("DragLaunch is missing");}
		//SetMouseXOffest ();

		//TODO Test code delete after complete.
		if (testDelay > 0) {
			Invoke ("Test", testDelay);
		}
	}
	
	// Update is called once per frame
	void Update () {
		// All drag system
		//float ballPosX;
		//if (!dragLaunch.CheckLaunched()) {
		//	ballPosX = Input.mousePosition.x - offSetX;
		//	if(minX<=ballPosX && ballPosX<=maxX){
		//		transform.position = new Vector3 (Input.mousePosition.x-offSetX, startPos.y, startPos.z);
		//	}
		//}
	}

	//TODO Test code delete after complete.
	public void Test(){
		Launch (launchVector);
		dragLaunch.Test ();
	}


	public void Launch (Vector3 velocity)
	{
		rigidBody.isKinematic = false;
		//rigidBody.useGravity=true;
		rollingSound.Play ();
		rigidBody.velocity = velocity;
	}



	public void Reset(){
		//Debug.Log ("Reset the bowling ball");
		//Reset all rigid body.
		//rigidBody.useGravity=false;
		//rigidBody.velocity = Vector3.zero;
		//rigidBody.angularVelocity = Vector3.zero;
		// Freeze movement, rotation and gravity. Can be replace by isKinemativ.
		rigidBody.isKinematic = true;
		//Reset all transform.
		transform.position = startPos;
		//transform.eulerAngles = startRot;
		transform.rotation = Quaternion.Euler (startRot);
		//Unlock scrolling
		dragLaunch.CheckLaunched();
		//Unlock Drag launch.
		dragLaunch.Reset ();
	}

	// Fake physics, which I tried to make the bowling launch at the first time.
	//void RollFoward(){
	//	transform.position += new Vector3 (0f, 0f, launchSpeed*Time.deltaTime);
		//transform.Rotate (Vector3.right * rollSpeed * Time.deltaTime);
	//}
		
	//void SetMouseXOffest (){
	//	offSetX = Screen.width / 2f;
	//}
}
