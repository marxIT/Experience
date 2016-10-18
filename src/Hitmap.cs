using UnityEngine;
using System.Collections;

public class Hitmap : MonoBehaviour {

	public float count = 0;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		count+=Time.deltaTime * 1;
	}

}
