using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BowlingBall))]
public class DragLaunch : MonoBehaviour {

	//public float fullPower = 1000f, minPower = 200f;
	[Tooltip ("The max time to wait before auto reset.")]
	public float countDown = 30f, minBallSpeed = 150f;

	private Vector3 startPos, endPos;
	private float startTime, endTime, distanceToCamera, startPlayTime; //launchPower;

	private BowlingBall ball;
	//private PinSetter pinSetter;
	private bool isLaunched = false;


	// Use this for initialization
	void Start () {
		if (GameObject.FindObjectOfType<BowlingBall> ()) {
			ball = GameObject.FindObjectOfType<BowlingBall> ();
		} else {Debug.LogWarning ("BowlingBall missing.");}
		//if (GameObject.FindObjectOfType<PinSetter> ()) {
		//	pinSetter = GameObject.FindObjectOfType<PinSetter> ();
		//} else {Debug.LogWarning ("PinSetter missing.");}

		distanceToCamera = (transform.position.z - Camera.main.transform.position.z);
		startTime = -1;
	}
	
	// Update is called once per frame
	void Update () {
		// CountDown to prevent very slow launch to take forever.
		if (startTime >0 && Time.time > startTime + countDown) {
			ball.Reset ();
		}

	}

	void CaculateLaunchVelosity(){
		Vector2 trail;
		float deltaTime;
		trail = endPos - startPos;
		deltaTime = endTime - startTime;
		//launchPower = trail.magnitude / deltaTime * fullPower;
		//Debug.Log (trail + "trail.magnitude is "+trail.magnitude+ ", deltaTime is "+deltaTime + ", launchPower is "+ launchPower);
		Vector3 launchVelocity = new Vector3 (trail.x/deltaTime,0f,trail.y/deltaTime);
		if (launchVelocity.z < minBallSpeed) {	// slow check
			isLaunched = false;
			Debug.LogWarning ("Ball too slow. Relaunch is granted.");
			return;
		}
		//if (isLaunched) {return;}
		ball.Launch(launchVelocity);
		Debug.Log ("Bowling ball launched at "+launchVelocity);
	}

	// TODO Prevent ball launch when swiper is animating.
	// Capture time & position of drag start
	public void DragStart(){
		if (isLaunched) {return;}
		startPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera));
		startTime = Time.time;
		//Debug.Log ("startPos is "+startPos+ ", startTime is "+startTime);
		//ball.Ready ();
	}

	// Launch the ball
	public void DragEnd(){
		// Prevent multiple launch
		if (isLaunched) {return;}
		endPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera));
		endTime = Time.time;
		//Debug.Log ("endPos is "+endPos+ ", endTime is "+endTime);
		isLaunched = true;	// must before CaculateLaunchVelosity (), or the slow check will fail.
		CaculateLaunchVelosity ();
	}

	public void MoveStart(float xNudge){
		if (!isLaunched) {
			if (xNudge > 0 & transform.position.x <= 52-xNudge) {
				transform.position += new Vector3 (xNudge, 0f, 0f);
			}
			if (xNudge < 0 && transform.position.x >= -52-xNudge) {
				transform.position += new Vector3 (xNudge, 0f, 0f);
			}
		}
	}

	public void StopLaunch(){
		isLaunched = true;
	}

	public void Reset (){
		startTime = -1;
		isLaunched = false;
	}

	public bool CheckLaunched(){
		return isLaunched;
	}
		
	//TODO Delete after completed.
	public void Test(){
		isLaunched = true;
	}
}
