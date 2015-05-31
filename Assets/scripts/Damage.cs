using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]

/**
 * プレーヤのダメージ処理 
 */
public class Damage : MonoBehaviour {

	public GameObject hpbar;

	public bool onDamage = false;

	private new SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		// 点滅処理のために呼び出しておく
		renderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Motion発動
		//GetComponent<Animator> ().SetBool ("isDamage", onDamage);
		// 攻撃フラグをAnimatorに設定する
		if (onDamage) {
			float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
			renderer.color = new Color(11f,1f,1f,level);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		// 無敵状態の処理
		if (Player.isBigPalFlg && (col.gameObject.tag == "enemy" || col.gameObject.tag == "black_bone")) {
			Destroy(col.gameObject);
			Score.instance.Add();
			hpbar.gameObject.SendMessage("onDamage", -10);
			return;
		}

		// enemyに当たったら50のダメージをパルが受ける
		if (!onDamage && col.gameObject.tag == "enemy" || col.gameObject.tag == "black_bone") {
			Destroy(col.gameObject);
			hpbar.gameObject.SendMessage("onDamage", 30);
			OnDamageEffect();
		}
		// 回復アイテム
		if (col.gameObject.tag == "item") {
			hpbar.gameObject.SendMessage("onDamage", -5);
		}
		if (col.gameObject.tag == "niku") {
			hpbar.gameObject.SendMessage("onDamage", -30);
		}
	}

	void OnDamageEffect() {
		onDamage = true;
		// Playerを後ろに飛ばす
//		float s = 100f * Time.deltaTime;
//		transform.Translate (Vector3.up * s);
//		transform.Translate (Vector3.left * s);
		StartCoroutine ("WaitForIt");
	}

	IEnumerator WaitForIt() {
		// 1秒間処理を止める(これで点滅状態のまま1秒間無敵状態になる)
		yield return new WaitForSeconds(1);

		// 1秒後ダメージフラグをfalseにして点滅を戻す
		onDamage = false;
		renderer.color = new Color(1f,1f,1f,1f);
	}
}
