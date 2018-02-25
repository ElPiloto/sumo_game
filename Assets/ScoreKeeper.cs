using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	public GameObject[] players;
	public GameObject groundPlane;

	private int[] scores;

	// Use this for initialization
	void Start () {
		 scores = new int[players.Length];
		for (int i = 0; i < players.Length; i++){
			scores[i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < players.Length; i++){
			if (players[i].transform.position.y + players[i].GetComponent<Collider>().bounds.size.y < groundPlane.transform.position.y) {
				scores[i]--;
				Debug.Log(string.Format("Player {0} fell and now has score {1}",i,scores[i]));
				players[i].transform.position = new Vector3(Random.RandomRange(-1.5f, 1.5f),
															4.0f,
															Random.RandomRange(-1.5f, 1.5f));
			}		
		}
	}
}
