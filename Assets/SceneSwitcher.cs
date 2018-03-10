using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	public Button startButton;
	public Button quitButton;

	// Use this for initialization
	void Start () {
		/*startButton.OnPointerClick.
		startButton.OnPointerClick(delegate {LoadStart(); });
		quitButton.OnPointerClick.AddListener(delegate {QuitGame(); });
		//startButton.onClick.AddListener += LoadStart;
		//quitButton.onClick.AddListener(QuitGame);*/
	}
	
	 public void LoadStart () {
		Debug.Log("You have clicked the button!");
		SceneManager.LoadScene (1);
	}

	 public void QuitGame() {
		Debug.Log("You have clicked the QUIT button!");
		Application.Quit ();
	}
}
