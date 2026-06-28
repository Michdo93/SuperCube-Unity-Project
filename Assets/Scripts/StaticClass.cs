using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class StaticClass : MonoBehaviour {
	static public int score;
	static public int highscore;
	static public string highscorePath;
	static public bool music = true;
	static public bool sound = true;
	static public JSONNode strings;
	static public string selectedLanguage;
	static public GUIManager instance;
	static public GUIController inst;
}
