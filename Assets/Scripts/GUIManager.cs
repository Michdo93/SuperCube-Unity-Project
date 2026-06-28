using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class GUIManager : MonoBehaviour {
	//public static GUIManager instance;
	public JSONNode strings;
	public Dropdown language;
	public Text label;

	private bool dataLoaded = false;
	private string nameStrings = "/ExternalData/strings.json";

	public void Awake() {
		StaticClass.instance = this;
	}

	private void Start() {
		if (StaticClass.selectedLanguage == null) {
			StaticClass.selectedLanguage = "English";
		} else {
			strings = StaticClass.strings;
			GUIController.changeMenu ();
		}

		label.text = StaticClass.selectedLanguage;
		StartCoroutine (loadData());
	}

	IEnumerator loadData() {
		string prefix = "";
		string pathname;
		string iniData;

		if (!Application.isWebPlayer)
			prefix = "file://";

		pathname = prefix + Application.dataPath + "/.." + nameStrings;
		WWW www = new WWW (pathname);
		yield return www;

		iniData = www.text;
		strings = JSON.Parse (iniData) as JSONNode;
		dataLoaded = true;

		if(dataLoaded) {
			for (int i = 0; i < strings.Count; i++) {
				language.options.Add (new Dropdown.OptionData (strings [i] ["type"].Value));
			}

			language.onValueChanged.AddListener(delegate {
				StaticClass.selectedLanguage = strings[language.value]["type"];
				GUIController.changeMenu();
			});
			StaticClass.strings = strings;
		}
	}
}