using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	private AudioSource musicSource;

	// Use this for initialization
	void Start () {
		musicSource = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (StaticClass.music) {
			musicSource.mute = false;
		}

		if(!StaticClass.music) {
			musicSource.mute = true;
		}
	}
}
