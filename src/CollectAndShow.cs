using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectAndShow : MonoBehaviour {

	public AudioClip paperaudio;
	public bool hasread = false;
	RawImage content;
	Text exit;



	// Use this for initialization
	void Start () {

		content = GameObject.Find("Content").GetComponent<RawImage>();
		exit = GameObject.Find("exit").GetComponent<Text>();

	}

	void OnTriggerEnter(Collider col){
	if (col.tag == "Player") {
			content.enabled = true;
			AudioSource.PlayClipAtPoint(paperaudio,transform.position);
			GameObject.FindWithTag("Player").GetComponent<CharacterController>().enabled = false;
			exit.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (exit.enabled == true) {
				if (Input.GetMouseButton(1)) {
				Destroy(gameObject);
				AudioSource.PlayClipAtPoint(paperaudio,transform.position);
				GameObject.FindWithTag("Player").GetComponent<CharacterController>().enabled = true;
				content.enabled = false;
				exit.enabled = false;
				hasread = true;

				}
		}

	
	}
}
