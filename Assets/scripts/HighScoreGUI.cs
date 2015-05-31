using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreGUI : MonoBehaviour {

	private Text sText;
	
	void Start () {
		sText = GetComponent<Text> ();
		int score = PlayerPrefs.GetInt ("HIGH_SCORE");
		string scoreAddZero = score.ToString("000");
		sText.text = "HIGH: " + scoreAddZero;
	}

	void Update () {
	
	}
}
