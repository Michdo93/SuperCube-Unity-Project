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

	private const string BACKEND_URL = "https://supercube-backend.onrender.com";

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

	IEnumerator getHighscore()
	{
		string url = BACKEND_URL + "/highscores";

		WWW www = new WWW(url);
		yield return www;

		if (!string.IsNullOrEmpty(www.error))
		{
			Debug.LogWarning("Highscore laden fehlgeschlagen: " + www.error);
			// Platzhalter setzen damit die UI nicht leer bleibt
			for (int i = 0; i < highscorePointsText.Count; i++)
			{
				highscorePointsText[i].text = "-";
				highscoreNameText[i].text = "-";
			}
			yield break;
		}

		HighscoreData score = JsonUtility.FromJson<HighscoreData>(www.text);

		for (int i = 0; i < highscorePointsText.Count; i++)
		{
			if (i < score.scores.Length)
			{
				highscorePointsText[i].text = score.scores[i].points;
				highscoreNameText[i].text = score.scores[i].name;
			}
			else
			{
				highscorePointsText[i].text = "-";
				highscoreNameText[i].text = "-";
			}
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

