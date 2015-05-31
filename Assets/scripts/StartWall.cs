using UnityEngine;
using System.Collections;

public class StartWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// BOX個ライダーの衝突開始コールバック
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "item"
		    || col.gameObject.tag == "niku"
		    || col.gameObject.tag == "enemy" 
		    || col.gameObject.tag == "bone" 
		    || col.gameObject.tag == "black_bone") {
			Destroy(col.gameObject);
		}
	}
}
