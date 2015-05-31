using UnityEngine;
using System.Collections;

/**
 * スコアアイテムの自動生成
 */
public class Spawner : MonoBehaviour {

	// 生成するプレハブ
	public GameObject prefab;
	// 生成時の速さ
	public Vector3 velocity = Vector3.left;
	// 初めて生成するまでにかかる時間
	public float offsetTime = 0f;
	// 生成するタイミング
	public float intervalTime = 3f;
	
	// このクラスが管理する時間
	private float mTime = 0f;
	
	// Use this for initialization
	void Start () {
		mTime = -offsetTime;
	}
	
	// Update is called once per frame
	void Update () {
		mTime += Time.deltaTime;
		
		if (mTime < 0f) {
			return;
		}
		
		if (mTime >= intervalTime) {
			Vector3 randomPos = Vector3.one;
			randomPos.x = 9.5f;//固定
			randomPos.y = Random.Range (0, 8);
			GameObject obj = Instantiate (prefab, randomPos, transform.rotation) as GameObject;
			obj.GetComponent<Rigidbody2D>().velocity = velocity;
			mTime = 0f;
		}
	}
}