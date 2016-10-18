using UnityEngine;
using System.Collections;

public class JumpScare : MonoBehaviour {

	public int triggerType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.GetComponent<AudioSource>().isPlaying == false){
			transform.GetComponent<MeshRenderer>().enabled = false;
		}
	}

	void OnTriggerEnter(Collider other){

		if(other.tag == "Player") {
			if(triggerType == 1){
				transform.GetComponent<MeshRenderer>().enabled = true;
				transform.GetComponent<AudioSource>().Play();
			} else if (triggerType == 2) {
				transform.GetComponent<AudioSource>().Play();
			} else if (triggerType == 3) {
				Destroy(gameObject);
				Application.LoadLevel(2);
			}
		}
	}
}
