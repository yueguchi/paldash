using UnityEngine;
using System.Collections;

public class Bone : MonoBehaviour {
	public float speed = 10;
	void Update () {
		//右へ移動
		transform.position += Vector3.right * speed * Time.deltaTime;
	}
	
	// カメラから見えなくなったら呼ばれる
	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
