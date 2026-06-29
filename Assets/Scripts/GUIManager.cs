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
    // Hier nur den reinen Ordner- und Dateinamen angeben
    private string nameStrings = "ExternalData/strings.json";

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
        string pathname;
        string iniData;

        // Unterscheidung zwischen WebGL-Browser und lokalem Unity Editor/PC-Build
#if UNITY_WEBGL && !UNITY_EDITOR
        // Application.absoluteURL liefert z.B. "https://michdo93.github.io/SuperCube/"
        // Wir hängen einfach den Pfad zur JSON-Datei an.
        pathname = Application.absoluteURL + nameStrings;
#else
        // Für den lokalen Unity Editor: Nutzt den korrekten lokalen file:// Pfad
        pathname = "file://" + Application.dataPath + "/../" + nameStrings;
#endif

        // Debug-Ausgabe in der Browser-Konsole, damit du genau siehst, was geladen wird
        Debug.Log("Lade Strings von Pfad: " + pathname);

        WWW www = new WWW (pathname);
        yield return www;

        // Fehler abfangen, falls beim Laden etwas schiefgeht
        if (!string.IsNullOrEmpty(www.error)) {
            Debug.LogError("Fehler beim Laden der JSON: " + www.error);
            yield break;
        }

        iniData = www.text;
        strings = JSON.Parse (iniData) as JSONNode;
        dataLoaded = true;

        if(dataLoaded && strings != null) {
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