using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	void OnMouseUp() {
		Debug.Log("Hello");
		SceneManager.LoadScene (1);
	}
}
