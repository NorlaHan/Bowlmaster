using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	void OnTriggerExit(Collider objLeft){
		if (objLeft.GetComponent<Pin>()) {
			Destroy(objLeft.gameObject);
		}
	}
}
