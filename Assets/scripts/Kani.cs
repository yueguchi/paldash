using UnityEngine;
using System.Collections;

public class Kani : MonoBehaviour {
	
	public float speed = 10;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// 左へ移動
		transform.position += Vector3.left * speed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "item") {
			Destroy (col.gameObject);
		}
	}
}
