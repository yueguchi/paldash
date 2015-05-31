using UnityEngine;
using System.Collections;

public class BlackBone : MonoBehaviour {
	public float speed = 10;
	void Update () {
		//左へ移動
		transform.position += Vector3.left * speed * Time.deltaTime;
	}
	
	// カメラから見えなくなったら呼ばれる
	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
