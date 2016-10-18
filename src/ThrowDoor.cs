using UnityEngine;
using System.Collections;

public class ThrowDoor : MonoBehaviour {


	public float hoverForce = 100;
	public AudioClip thud;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * hoverForce,ForceMode.Impulse);
			AudioSource.PlayClipAtPoint(thud,transform.position);
			NavigationScript.StartChase = true;

		}
	}
}
