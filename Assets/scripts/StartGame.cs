using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Hpbar.sceneHp = 250;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGame() {
		PlayerPrefs.DeleteKey ("nowScore");
		Application.LoadLevel ("main");
	}

	public void endGame() {
		Application.Quit ();
	}

	public void sendLine() {
		int score = PlayerPrefs.GetInt ("HIGH_SCORE");
		string scoreAddZero = score.ToString("000");
		string highScore = "【ぱるだっしゅ】HIGH: " + scoreAddZero + "点を叩き出しました!!";
		Application.OpenURL("http://line.naver.jp/R/msg/text/?" + WWW.EscapeURL(highScore, System.Text.Encoding.UTF8));
	}
}