using UnityEngine;
using System.Collections;

public class DropBody : MonoBehaviour {


	public float hoverForce = 100;
	public AudioClip thud;
	bool hasEnabled = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(hasEnabled == false){
			if(other.tag == "Player"){
				Rigidbody myBody = GameObject.Find("QHBodyDrop").GetComponent<Rigidbody>();
				
				myBody.AddForce(-transform.forward * hoverForce,ForceMode.Impulse);
				AudioSource.PlayClipAtPoint(thud,transform.position);
				hasEnabled = true;
				
			}
		}

	}
}
