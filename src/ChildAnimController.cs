using UnityEngine;
using System.Collections;

public class ChildAnimController : MonoBehaviour {


	protected Animator myAnimator;

	// Use this for initialization
	void Start () {
	
		myAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			myAnimator.SetBool ("IsWalking", true);
		}
	}
}
