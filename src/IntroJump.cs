using UnityEngine;
using System.Collections;

public class IntroJump : MonoBehaviour {

	public bool activateNow = false;
	public Transform Player;
	float Damping = 6.0f;
	private Vector3 MoveDirection = Vector3.zero;
	float MoveSpeed = 5.0f;
	float gravity = 20.0f;
	public CharacterController myChar;
	bool hasActivated;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		if(activateNow == true){
//			ActiveNow();
			if (activateNow == true) {
				hasActivated = true;
			}
			//var rotation = Quaternion.LookRotation(Player.transform.position - transform.position);
			//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);

			//MoveDirection = transform.forward;
			//MoveDirection *= MoveSpeed;
			//MoveDirection.y -= gravity * Time.deltaTime;
			//myChar.Move(MoveDirection * Time.deltaTime);
			//transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);


//		}

		if(hasActivated == true) {
			walk();
		}

	}

	void walk(){
		var rotation = Quaternion.LookRotation(Player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
		
		MoveDirection = transform.forward;
		MoveDirection *= MoveSpeed;
		MoveDirection.y -= gravity * Time.deltaTime;
		myChar.Move(MoveDirection * Time.deltaTime);
	}


	public void ActiveNow(){
		transform.GetComponent<AudioSource>().Play ();
		transform.GetComponent<MeshRenderer>().enabled = true;
		transform.GetComponent<CapsuleCollider>().enabled = true;
		transform.GetComponent<SphereCollider>().enabled = true;
		transform.GetComponentInChildren<Light>().enabled = true;
		activateNow = true;
	}
}
