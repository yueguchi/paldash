﻿using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {

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
}