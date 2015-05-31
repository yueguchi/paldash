using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	private static Score sInstance;
	
	public static Score instance {
		get {
			if (sInstance == null) {
				sInstance = FindObjectOfType<Score>();
			}
			return sInstance;
		}
	}
	
	// Use this for initialization
	public void Start () {
		if (this != instance) {
			Destroy(this);
		}
	}
	
	public int score {
		get;
		private set;
	}
	
	public void Add() {
		score++;
		if (score != 0 && (score % 100) == 0 && Application.loadedLevelName == "main") {
			PlayerPrefs.SetInt("nowScore", Score.instance.score);
			Application.LoadLevel("boss");
		}
	}

	public void Add(int s) {
		score += s;
	}

	public void Reset() {
		score = 0;
	}
}
