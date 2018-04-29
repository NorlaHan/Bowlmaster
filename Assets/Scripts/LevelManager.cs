using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private int sceneIndex;
	private MusicManager musicManager;
	public GameObject musicManagerPrefab;

	// Use this for initialization
	void Start () {
		sceneIndex = SceneManager.GetActiveScene ().buildIndex;

		if (GameObject.FindObjectOfType<MusicManager>()) {
			PlayMusic ();
		}else{Debug.LogWarning ("MusicManager missing!");}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayMusic ()
	{
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		musicManager.LoadMusicOnLevelStart (sceneIndex);
		DontDestroyOnLoad (musicManager.gameObject);
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene (sceneIndex+1);
	}
}
