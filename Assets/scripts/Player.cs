using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]

/**
 * 主人公の行動スクリプト
 */
public class Player : MonoBehaviour {
	
	/** 多段ジャンプの回数上限 */
	public int maxJumpCount = 2;
	/** 上向きの力をどれだけ与えるか */
	public float jumpPower = 10;
	/** 骨 */
	public GameObject firePrefab;


	/** RigidBody2d */
	private Rigidbody2D rigid;
	/** ジャンプ可能かどうか */
	private bool isJump = false;
	/** ジャンプ回数 */
	private int jumpCount = 0;
	/** 開始位置X */
	private float startX;
	/** 攻撃フラグ */
	private bool isAttack = false;
	/** 巨大化フラグ */
	public static bool isBigPalFlg = false;
	// 音楽系
	private AudioSource audioSource;
	public AudioClip getNikuSE;
	public AudioClip getItemSE;

	// 初回コール
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		this.startX = transform.position.x;
		audioSource = GetComponent<AudioSource> ();
	}
	
	// 1秒間に画面が描画されるたびにコールされる
	void Update () {

		if (Application.loadedLevelName.Contains("boss") && CountDown._textCountdown.text != "") {
			return;
		}

		if (jumpCount < maxJumpCount && (Input.GetButtonDown("Jump") || CrossPlatformInputManager.GetButtonDown("Jump"))) {
			isJump = true;
		}

		// 攻撃
		if (Input.GetKeyDown(KeyCode.F) || CrossPlatformInputManager.GetButtonDown("Fire1")) {
			isAttack = true;
		}

	}

	// 一定間隔でコールされる
	void FixedUpdate () {
		if (isJump) {
			rigid.velocity = Vector3.up * jumpPower;
			jumpCount++;
			isJump = false;
		}
		if (isAttack) {
			float bonePosX = transform.position.x + 3;
			Instantiate (firePrefab, new Vector3 (bonePosX, transform.position.y, 1), Quaternion.identity);
			isAttack = false;
		}
	}

	// BOX個ライダーの衝突開始コールバック
	void OnCollisionEnter2D(Collision2D col) {
		// ジャンプ処理のための地面衝突処理
		if (col.gameObject.tag == "ground") {
			jumpCount = 0;
		}

		if (col.gameObject.tag == "item" || col.gameObject.tag == "niku") {
			soundItem(col.gameObject.tag);
			// アイテムを取ると横軸に移動する可能性があるため調整
			transform.position = new Vector2(startX, transform.position.y);
			Destroy(col.gameObject);
			Score.instance.Add();
		}
		// ゴミをとったら-10点
		if (col.gameObject.tag == "gomi") {
			Destroy(col.gameObject);
			Score.instance.Add(-10);
		}
	}

	void soundItem(string tag) {
		if (tag == "item") {
			audioSource.PlayOneShot (getItemSE);
		} else if (tag == "niku") {
			audioSource.PlayOneShot(getNikuSE);
		}
	}
}
