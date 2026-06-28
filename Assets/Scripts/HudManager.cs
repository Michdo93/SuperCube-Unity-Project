using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {
	public Text scoreLabel;

	// Use this for initialization
	void Start () {
		RefreshScore ();
	}
	
	void FixedUpdate () {
		RefreshScore ();
	}

	public void RefreshScore() {
		//scoreLabel.text = "Score: " + StaticClass.score;
		scoreLabel.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["score"] + ": " + StaticClass.score;
	}

	private void getCoin(GameObject coin) {
		GameManager.instance.AddScore(1);
		Destroy(coin);
	}
}
