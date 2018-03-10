using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDisplayer : MonoBehaviour {
	public Text text;
	public Slider slider;

	// Use this for initialization
	void Start () {
		slider.onValueChanged.AddListener(delegate {SetText(); });
		text.text = "Num Players: " + slider.value.ToString ();
	}

	void SetText() {
		//text.text = slider.value.ToString ();
		text.text = "Num Players: " + slider.value.ToString ();
	}

}
