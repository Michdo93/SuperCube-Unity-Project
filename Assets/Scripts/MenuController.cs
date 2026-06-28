using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	public static MenuController instance;

	public Transform mainMenu;
	public Transform howTo;
	public Transform options;
	public Transform highscore;
	public Transform credits;

	public List<Text> highscorePointsText;
	public List<Text> highscoreNameText;

	public void showMainMenu() {
		mainMenu.gameObject.SetActive (true);
		howTo.gameObject.SetActive (false);
		options.gameObject.SetActive (false);
		highscore.gameObject.SetActive (false);
		credits.gameObject.SetActive (false);
	}

	public void showHowTo() {
		mainMenu.gameObject.SetActive (false);
		howTo.gameObject.SetActive (true);
		options.gameObject.SetActive (false);
		highscore.gameObject.SetActive (false);
		credits.gameObject.SetActive (false);
	}

	public void showOptions() {
		mainMenu.gameObject.SetActive (false);
		howTo.gameObject.SetActive (false);
		options.gameObject.SetActive (true);
		highscore.gameObject.SetActive (false);
		credits.gameObject.SetActive (false);
	}

	public void showHighscore() {
		StartCoroutine (getHighscore ());

		mainMenu.gameObject.SetActive (false);
		howTo.gameObject.SetActive (false);
		options.gameObject.SetActive (false);
		highscore.gameObject.SetActive (true);
		credits.gameObject.SetActive (false);
	}

	public void showCredits() {
		mainMenu.gameObject.SetActive (false);
		howTo.gameObject.SetActive (false);
		options.gameObject.SetActive (false);
		highscore.gameObject.SetActive (false);
		credits.gameObject.SetActive (true);
	}

	IEnumerator getHighscore() {
		string url = "https://webuser.hs-furtwangen.de/~doerflim/Spiele3D/SuperCube/showhighscore.php";

		WWW www = new WWW (url);
		yield return www;

		HighscoreData score = JsonUtility.FromJson<HighscoreData> (www.text);

		for(int i = 0; i < highscorePointsText.Count; i++) {
			highscorePointsText[i].text = score.scores[i].points;
			highscoreNameText [i].text = score.scores [i].name;
		}
	}

	public class HighscoreData {
		[System.Serializable]
		public class Scores {
			public string points;
			public string name;
		}
		public Scores [] scores;
	}
}

