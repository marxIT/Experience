using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HideText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(MyCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator MyCoroutine()
	{
		//This is a coroutine
		yield return new WaitForSeconds(4.0f);
		hidetext();

		//Wait one frame


	}

	void hidetext(){
		GameObject.Find ("Text").SetActive (false);
	}
}
