using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public static int hp = 1000;
	private bool onDamage = false;
	public GameObject explosion;
	public GameObject ex_sounds;
	public GameObject ex_mush;
	private bool isGameOver = false;
	private float deadTimer = 5.0f;

	void Start() {
		hp = 1000;
		if (Score.instance.score <= 0) {
			int score = PlayerPrefs.GetInt("nowScore");
			Score.instance.Add (score);
		}
	}

	void Update () {
		if (onDamage) {
			onDamage = false;
		}
		if (isGameOver) {
			deadTimer -= Time.deltaTime;
			if (deadTimer <= 0f) {
				Score.instance.Add(101);
				PlayerPrefs.SetInt("nowScore", Score.instance.score);
				Application.LoadLevel ("main");
			}
		}

	}

	void OnCollisionEnter2D(Collision2D col) {
		// boneはパルからの攻撃なのでダメージ
		if (col.gameObject.tag == "bone" && onDamage == false) {
			hp -= 10;
			if (hp <= 0) {
				//Instantiate(ex_sounds, new Vector3 (transform.position.x, transform.position.y, 1), Quaternion.identity);
				//Instantiate(ex_mush, new Vector3 (transform.position.x, transform.position.y, 1), Quaternion.identity);
				//Instantiate(explosion, new Vector3 (transform.position.x, transform.position.y, 1), Quaternion.identity);
				Destroy(col.gameObject);
				transform.localScale = new Vector2(0f, 0f);
				StartCoroutine(WaitFotNextStage());
			}
			Destroy(col.gameObject);
			onDamage = true;
		}
	}

	IEnumerator WaitFotNextStage() {
		isGameOver = true;
		yield return new WaitForSeconds(5f);
	}
}
