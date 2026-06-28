using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {
	private Toggle musicToggle;

	// Use this for initialization
	void Start () {
		musicToggle = this.GetComponent<Toggle> ();
		if (StaticClass.music == false)
			musicToggle.isOn = false;
	}

	public void onToggle() {
		StaticClass.music = musicToggle.isOn;
	}
}
