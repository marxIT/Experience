using UnityEngine;
using System.Collections;

public class StopStartChase : MonoBehaviour {

	bool hasPassed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			if(hasPassed == false){
				NavigationScript.StartChase = false;
			} else {
				NavigationScript.StartChase = true;
			}
		}


	}
}
