using UnityEngine;
using System.Collections;

public class ToLastScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		//Random r = new Random();
		if(other.tag == "Player"){
			Application.LoadLevel (3);
		}
	}
}
