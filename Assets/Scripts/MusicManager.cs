using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] audioClips= new AudioClip[2];
	public float AudioVolume = 0.5f;

	private AudioSource audioSource;
	// Use this for initialization
	void Start () {

		if (GetComponent<AudioSource> ()) {
			audioSource = GetComponent<AudioSource> ();
		} else {Debug.LogWarning ("AuidoSource not found");}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadMusicOnLevelStart (int sceneIndex)
	{
		audioSource.clip = audioClips [sceneIndex];
		audioSource.volume = AudioVolume;
		audioSource.Play ();
	}
}
