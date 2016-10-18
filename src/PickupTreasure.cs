using UnityEngine;
using System.Collections;

public class PickupTreasure : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			Destroy(gameObject);
			Destroy(GameObject.FindWithTag("Enemy"));
			Application.Quit ();
		}
	}
}
