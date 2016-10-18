using UnityEngine;
using System.Collections;

public class StopQhChase : MonoBehaviour {
	bool isActive;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isActive == true){
			transform.GetComponent<BoxCollider>().enabled = true;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			QhChase.StartChaseQh = false;
		}
	}
}
