using UnityEngine;
using System.Collections;

public class Boss_poodle_ai : MonoBehaviour {

	public GameObject firePrefab;

	public int gravityPower = 6;
	public int shotUpPower = 800;
	
	private int move_type = 0;
	
	private bool isIdle = true;
	private int attackCount = 0;

	// Update is called once per frame
	void Update () {
		if (CountDown._textCountdown.text != "") {
			return;
		}
		
		if (Boss.hp <= 0) {
			return;
		}
		
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
			for (int i = 0; i < 3; i++) {
				GameObject fire = Instantiate(firePrefab, new Vector3(transform.position.x -3, 2, 1), Quaternion.identity) as GameObject;
				Rigidbody2D rigid = fire.gameObject.GetComponent<Rigidbody2D> ();
				rigid.gravityScale = gravityPower;
				rigid.AddForce(transform.up * shotUpPower);
				// 攻撃オブジェクトのタグを変える
				fire.gameObject.tag = "black_bone";
				yield return new WaitForSeconds(1f);
			}
			attackCount = 0;
			yield return new WaitForSeconds(2.0f);
			isIdle = true;
		}
	}
}
