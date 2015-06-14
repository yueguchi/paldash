using UnityEngine;
using System.Collections;

public class Hpbar : MonoBehaviour {

	public static float sceneHp = 250;


	// Use this for initialization
	void Start () {
		Rect hpRect = GetComponent<GUITexture> ().pixelInset;
		hpRect.width = sceneHp;
		GetComponent<GUITexture>().pixelInset = hpRect;
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

	void OnDestroy() {
		if (Application.loadedLevelName == "main" || Application.loadedLevelName.Contains("boss")) {
			Rect hpRect = GetComponent<GUITexture> ().pixelInset;
			sceneHp = hpRect.width;
		} else {
			sceneHp = 250;
		}
	}
}
