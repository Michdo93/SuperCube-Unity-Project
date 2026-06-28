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

	IEnumerator sendToHighscore() {
		string url = "https://webuser.hs-furtwangen.de/~doerflim/Spiele3D/SuperCube/sethighscore.php";

		WWWForm form = new WWWForm ();
		form.AddField ("points", StaticClass.score);
		form.AddField ("name", name.text);

		WWW www = new WWW (url, form);
		yield return www;

		SceneManager.LoadScene (0);
	}
}
