using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
	public Text highscoreLabel;
	public Text scoreLabel;
	public InputField name;

	public Text gameOverTitle;
	public Text yourHighscore;
	public Text yourPoints;
	public Text yourName;
	public Text send;
	public Text gameOverBack;
	private const string BACKEND_URL = "https://supercube-backend.onrender.com";

	private void Awake() {
		highscoreLabel.text = StaticClass.highscore.ToString();
		scoreLabel.text = StaticClass.score.ToString();
		changeGameOver();
	}

	private void changeGameOver() {
		gameOverTitle.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["gameOver"];
		yourHighscore.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["yourHighscore"];
		yourPoints.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["yourPoints"];
		yourName.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["yourName"];
		send.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["send"];
		gameOverBack.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["back"];
	}

	public void sendHighscore() {
		StartCoroutine (sendToHighscore ());
	}

	public void showMainMenu() {
		SceneManager.LoadScene(0);
	}

	IEnumerator sendToHighscore()
	{
		string url = BACKEND_URL + "/highscores";

		// JSON-Body bauen
		string playerName = name.text.Trim();
		if (string.IsNullOrEmpty(playerName)) playerName = "Anonym";
		string jsonBody = "{\"name\":\"" + playerName + "\",\"points\":" + StaticClass.score + "}";

		byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);

		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("Content-Type", "application/json");

		WWW www = new WWW(url, bodyRaw, headers);
		yield return www;

		if (!string.IsNullOrEmpty(www.error))
		{
			Debug.LogWarning("Highscore senden fehlgeschlagen: " + www.error);
		}
		else
		{
			Debug.Log("Highscore gesendet: " + www.text);
		}

		SceneManager.LoadScene(0);
	}
}
