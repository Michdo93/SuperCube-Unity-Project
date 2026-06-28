using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class GUIController : MonoBehaviour {
	//public static GUIController inst;

	//MainMenu
	public Text mainMenuTitle;
	public Text start;
	public Text howTo;
	public Text options;
	public Text highscore;
	public Text credits;

	//HowTo
	public Text howToTitle;
	public Text walkForward;
	public Text walkLeft;
	public Text walkBackwards;
	public Text walkRight;
	public Text jump;
	public Text w;
	public Text a;
	public Text s;
	public Text d;
	public Text space;
	public Text howToBack;

	//Options
	public Text optionsTitle;
	public Text music;
	public Text sound;
	public Text optionsBack;

	//Credits
	public Text creditsTitle;
	public Text createdBy;
	public Text musicBy;
	public Text creditsBack;

	//Loading
	public Text loading;

	public void Awake() {
		StaticClass.inst = this;
	}

	public static void changeMenu() {
		StaticClass.inst.mainMenuTitle.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["title"];
		StaticClass.inst.start.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["start"];
		StaticClass.inst.howTo.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["howTo"];
		StaticClass.inst.options.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["options"];
		StaticClass.inst.highscore.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["highscore"];
		StaticClass.inst.credits.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["credits"];

		StaticClass.inst.howToTitle.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["howTo"];
		StaticClass.inst.walkForward.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["walkForward"];
		StaticClass.inst.walkLeft.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["walkLeft"];
		StaticClass.inst.walkBackwards.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["walkBackwards"];
		StaticClass.inst.walkRight.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["walkRight"];
		StaticClass.inst.jump.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["jump"];
		StaticClass.inst.w.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["w"];
		StaticClass.inst.a.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["a"];
		StaticClass.inst.s.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["s"];
		StaticClass.inst.d.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["d"];
		StaticClass.inst.space.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["space"];
		StaticClass.inst.howToBack.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["back"];

		StaticClass.inst.optionsTitle.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["options"];
		StaticClass.inst.music.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["music"];
		StaticClass.inst.sound.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["sound"];
		StaticClass.inst.optionsBack.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["back"];

		StaticClass.inst.creditsTitle.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["credits"];
		StaticClass.inst.createdBy.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["createdBy"];
		StaticClass.inst.musicBy.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["musicBy"];
		StaticClass.inst.creditsBack.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["back"];

		StaticClass.inst.loading.text = StaticClass.instance.strings[StaticClass.selectedLanguage]["loading"];
	}
}
