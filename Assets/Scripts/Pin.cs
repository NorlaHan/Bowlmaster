using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3.0f,pinsRaiseHeight = 40f;
	public AudioClip[] audioClips;

	private Rigidbody rigidBody;
	private Vector3 pinAngles;
	private bool isKO = false;
	//private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		
	}

	public bool isStanding(){
		try {
			pinAngles = transform.eulerAngles;
			if(pinAngles.x >180){pinAngles.x = pinAngles.x-360;}
			if(pinAngles.z >180){pinAngles.z = pinAngles.z-360;}
			if (Mathf.Abs(pinAngles.x)<= standingThreshold && Mathf.Abs(pinAngles.z)<= standingThreshold && !isKO) {
				return true;
			}
		} catch{Debug.LogWarning ("Pin isStanding method is causing trouble!");}

		if (!isKO) {
			isKO = true;
//			try {
//				PinAudioRandom ();
//			} catch{Debug.LogWarning ("PinAudioRandom method is causing trouble!");}
//			try {
//				GetComponent<AudioSource>().Play ();
//			} catch{Debug.LogWarning ("Playing audio clip is causing trouble!");}
		}
		return false;
	}

//	void PinAudioRandom(){
//		AudioSource audioSource = GetComponent<AudioSource>();
//		int clipIndex = Random.Range (0, 5);
//		audioSource.clip = audioClips[clipIndex];
//		audioSource.pitch = Random.Range (0.85f, 1.15f);
//	}

	public void Raise(){
		if (isStanding ()) {
			//GetComponent<Rigidbody> ().useGravity = false;
			//GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
			//GetComponent<Rigidbody> ().velocity = Vector3.zero;
			GetComponent<Rigidbody>().isKinematic = true;
			//transform.eulerAngles = Vector3.zero;
			transform.rotation = Quaternion.identity;
			transform.position += new Vector3 (0, pinsRaiseHeight, 0);
		}
	}

	public void Lower(){
		if (isStanding ()) {
			transform.position += new Vector3 (0, -pinsRaiseHeight, 0);
			GetComponent<Rigidbody>().isKinematic = false;
			//GetComponent<Rigidbody> ().useGravity = true;
		}
	}
}
