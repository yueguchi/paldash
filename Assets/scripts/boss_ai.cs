using UnityEngine;
using System.Collections;

public class boss_ai : MonoBehaviour {
	
	public GameObject firePrefab;
	
	private int move_type = 0;
	
	private bool isIdle = true;
	private int attackCount = 0;

	// Update is called once per frame
	void Update () {
		
		//アイドル状態
		if (isIdle) {
			// ランダムでモーション種類基準となる番号を取得
			move_type = Random.Range (0, 2);
		} else {
			return;
		}
		//Attack
		if(move_type == 1){
			isIdle = false;
			attackCount++;
			//スリープ
			StartCoroutine("WaitFotAttack");
		}
	}
	
	IEnumerator WaitFotAttack() {
		if (attackCount == 1) {

			GameObject fire = Instantiate(firePrefab, new Vector3(transform.position.x -3, Random.Range (0, 2), 1), Quaternion.identity) as GameObject;
			// 攻撃オブジェクトのタグを変える
			fire.gameObject.tag = "black_bone";
			attackCount = 0;
			yield return new WaitForSeconds(2.0f);
			isIdle = true;
		}
	}
}