﻿using UnityEngine;
using System.Collections;

public class EnableCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
		GameObject.Find("IICTPaper").GetComponent<SphereCollider>().enabled = true;
			Destroy(gameObject);
		}
	}
}
