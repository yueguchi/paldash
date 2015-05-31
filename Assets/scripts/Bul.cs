using UnityEngine;
using System.Collections;

public class Bul : MonoBehaviour {

	public int hp = 50;
	public float speed = 10;
	private bool onDamage = false;
	public GameObject explosion;
	public GameObject ex_sounds;

	void Update () {
		// 左へ移動
		transform.position += Vector3.left * speed * Time.deltaTime;
		if (onDamage) {
			onDamage = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "item") {
			Destroy(col.gameObject);
		}
		// boneはパルからの攻撃なのでダメージ
		if (col.gameObject.tag == "bone" && onDamage == false) {
			Destroy(col.gameObject);
			hp -= 10;
			if (hp <= 0) {
				Instantiate(explosion, new Vector3 (transform.position.x, transform.position.y, 1), Quaternion.identity);
				Instantiate(ex_sounds, new Vector3 (transform.position.x, transform.position.y, 1), Quaternion.identity);
				Destroy(gameObject);
				Score.instance.Add();
			}
			onDamage = true;
		}
	}
}
