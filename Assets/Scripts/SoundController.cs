using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {
	private Toggle soundToggle;

	// Use this for initialization
	void Start () {
		soundToggle = this.GetComponent<Toggle> ();
		if (StaticClass.sound == false)
			soundToggle.isOn = false;
	}

	public void onToggle() {
		StaticClass.sound = soundToggle.isOn;
	}
}
