using UnityEngine;
using System.Collections;

public class LastWalkDel : MonoBehaviour {

	//public Transform destroyThis;
	public static bool hasCollided;

	// Use this for initialization
	void Start () {
		//destroyThis = GameObject.Find("Walk1").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		Destroy(GameObject.Find("Walk1"));
		hasCollided = true;
	}
}
