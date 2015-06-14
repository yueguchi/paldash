using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour {
	
	private static Score sInstance;
	Dictionary<int, string> bossScenes = new Dictionary<int, string>();

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
		bossScenes.Add (0, "boss2");
		bossScenes.Add (1, "boss");
		bossScenes.Add (2, "boss3");
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
			int index = Random.Range(0, 3);
			Debug.Log(bossScenes[index]);
			Application.LoadLevel(bossScenes[index]);
		}
	}

	public void Add(int s) {
		score += s;
	}

	public void Reset() {
		score = 0;
	}
}
