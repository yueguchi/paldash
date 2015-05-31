using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// 音楽系
	private AudioSource audioSource;
	public AudioClip failedSE;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.PlayOneShot (failedSE);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void menu(){
		Application.LoadLevel("start");
	}
}
