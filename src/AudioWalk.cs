using UnityEngine;
using System.Collections;

public class AudioWalk : MonoBehaviour {
	bool isWalking;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
			isWalking = true;
		}

		if(isWalking == true){
			transform.GetComponent<AudioSource>().Play();
		} else {
			transform.GetComponent<AudioSource>().Stop();
		}
	}
}
