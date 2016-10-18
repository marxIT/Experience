using UnityEngine;
using System.Collections;

public class QhChaseStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			QhChase.StartChaseQh = true;
			ThrowObject.throwable = true;
		}
	}
}
