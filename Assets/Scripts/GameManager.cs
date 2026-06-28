using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;

	public int level = 1;
	public int maxLevel = 1;

	public int session = 0;

	private void Awake () {
		
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);    
	}

	// Use this for initialization
	private void Start () {
		if (session == 0) {
			StaticClass.highscore = 0;
		} else {
			StaticClass.highscore = PlayerPrefs.GetInt ("highscore");
		}
		session++;
	}

	public void AddScore(int newScoreValue) {
		StaticClass.score += newScoreValue;

		if (StaticClass.score > StaticClass.highscore) {
			StaticClass.highscore = StaticClass.score;
			PlayerPrefs.SetInt ("highscore", StaticClass.highscore);
		}
	}

	// currently no further levels
	public void NextLevel() {
		if (level == maxLevel) {
			SceneManager.LoadScene ("GameOver");
		} else {
			level++;
			SceneManager.LoadScene ("Level" + level);
		}
	}

	public void Reset() {
		StaticClass.score = 0;
		level = 1;

		SceneManager.LoadScene ("Level" + level);
	}
}
