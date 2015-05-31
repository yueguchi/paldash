using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreGUI : MonoBehaviour {

	private Text sText;

	// Use this for initialization
	void Start () {
		sText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		int score = Score.instance.score;
		// 桁埋め
		string scoreAddZero = score.ToString("000");
		sText.text = "Score: " + scoreAddZero;
	}
}
