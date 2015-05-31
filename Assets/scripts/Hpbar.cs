using UnityEngine;
using System.Collections;

public class Hpbar : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onDamage(int damage) {
		Rect hpRect = GetComponent<GUITexture>().pixelInset;
		hpRect.width = (hpRect.width - damage);
		if (hpRect.width >= 250) {
			hpRect.width = 250;
		}
		if (hpRect.width <= 0) {
			hpRect.width = 0;
			int highScore = PlayerPrefs.GetInt("HIGH_SCORE");
			int nowScore = Score.instance.score;
			if (nowScore > highScore) {
				PlayerPrefs.SetInt("HIGH_SCORE", Score.instance.score);
			}
			PlayerPrefs.DeleteKey("nowScore");
			Score.instance.Reset();
			Application.LoadLevel("gameover");
		}
		GetComponent<GUITexture>().pixelInset = hpRect;
	}
}
