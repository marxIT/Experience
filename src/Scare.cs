using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scare : MonoBehaviour {
	
	private RawImage jumpscare;
	public bool isDestroy = false;
	private int timebeforescare = 0;
	public AudioClip scream;
	private Transform player;

	// Use this for initialization
	void Start () {
		
		jumpscare = GameObject.Find("rawScare").GetComponent<RawImage>();
		player = GameObject.FindWithTag("Player").transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isDestroy == true) {
			StartCoroutine(MyCoroutine());
		}
		
	}
	
	IEnumerator MyCoroutine()
	{
		//This is a coroutine
		yield return new WaitForSeconds(1.0f);
		Scares();
		
		yield return new WaitForSeconds(2.0f);
		disableScare();

		yield return new WaitForSeconds(2.0f);
		Application.Quit ();
		//Wait one frame
		
		
	}
	
	void Scares(){
		jumpscare.enabled = true;
		AudioSource.PlayClipAtPoint(scream,player.position);
		
	}
	void disableScare(){
		jumpscare.enabled = false;
		isDestroy = false;


	}


}
