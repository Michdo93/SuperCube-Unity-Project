using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour {
	public GameObject loadingScreenObject;
	public Slider slider;
	private AsyncOperation asyncOperation;

	public void startLoading(int _scene) {
		StaticClass.score = 0;
		StartCoroutine(loadingScreen(_scene));
	}

	IEnumerator loadingScreen(int _scene) {
		loadingScreenObject.SetActive (true);
		asyncOperation = SceneManager.LoadSceneAsync (_scene);
		asyncOperation.allowSceneActivation = false;

		while(!asyncOperation.isDone) {
			slider.value = asyncOperation.progress;

			if(asyncOperation.progress == 0.9f) {
				slider.value = 1f;
				asyncOperation.allowSceneActivation = true;
			}

			yield return null;
		}
	}
}
