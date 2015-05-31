using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Score.instance.score <= 0) {
			int score = PlayerPrefs.GetInt("nowScore");
			Score.instance.Add (score);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
