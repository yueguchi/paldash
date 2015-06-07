using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour {

	[SerializeField]
	public static Text _textCountdown;
	
	void Start() {
		if (_textCountdown == null) {
			_textCountdown = GetComponent<Text> ();
		}
		_textCountdown.text = "3";
		StartCoroutine(CountdownCoroutine());
	}

	IEnumerator CountdownCoroutine() {
		_textCountdown.gameObject.SetActive(true);
		
		_textCountdown.text = "3";
		yield return new WaitForSeconds(1.0f);
		
		_textCountdown.text = "2";
		yield return new WaitForSeconds(1.0f);
		
		_textCountdown.text = "1";
		yield return new WaitForSeconds(1.0f);
		
		_textCountdown.text = "GO!";
		yield return new WaitForSeconds(1.0f);
		
		_textCountdown.text = "";
		_textCountdown.gameObject.SetActive(false);
	}
}
