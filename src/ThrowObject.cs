using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour {
	public float hoverForce = 10;
	public AudioClip thud;
	bool hasPlayed;
	public static bool throwable;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(throwable == true){
			transform.GetComponent<BoxCollider>().enabled = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * hoverForce,ForceMode.Impulse);
			AudioSource.PlayClipAtPoint(thud,transform.position);
			hasPlayed = true;
			
		}
	}
}
