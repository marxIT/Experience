using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {


	//public Transform Way1;
	public Transform Target;
	Vector3 curPos;
	float Damping;
	float minDist = 5.0f;
	private Vector3 MoveDirection = Vector3.zero;
	float MoveSpeed = 5.0f;
	float gravity = 20.0f;
	CharacterController myChar;
	int _curPoint;
	public static bool toNextPoint;
	NavMeshAgent nav;
	protected Animator myAnim;
	private bool IsWalking;


	// Use this for initialization
	void Start () {
//		curPos = Way1.position;
		myChar = transform.GetComponent<CharacterController>();
		nav = transform.GetComponent<NavMeshAgent>();
		myAnim = GetComponent<Animator> ();
	}

	
	// Update is called once per frame
	void Update () {
		//Vector3 distance = Vector3.Distance(Target.position, transform.position);
		//float Distance = Vector3.Distance(Target.position, transform.position);

		/*if (Distance < minDist){
			lookAt();
		}**/
		_curPoint = NextWayPoint.curPoint;
		if(_curPoint == 1){
			Target = GameObject.Find("Way1").transform;
		} else if(_curPoint == 2){
			Target = GameObject.Find("Way2").transform;
		} else if(_curPoint == 3){
			Target = GameObject.Find("Way3").transform;
		} else if(_curPoint == 4){
			Target = GameObject.Find("Way4").transform;
		} else if(_curPoint == 5){
			Target = GameObject.Find("Way5").transform;
		} else if(_curPoint == 6){
			Target = GameObject.Find("Way6").transform;
		} else if(_curPoint == 7){
			Target = GameObject.Find("Way7").transform;
		} else if(_curPoint == 8){
			Target = GameObject.Find("Way8").transform;
		} else if(_curPoint == 9){
			Target = GameObject.Find("Way9").transform;
		} else if (_curPoint == 10){
			Destroy(gameObject);
		}

		if(toNextPoint == true){
		walk();
		}
	}

	void walk(){
		/*var rotation = Quaternion.LookRotation(Target.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);**/
		
	/*	MoveDirection = transform.forward;
		MoveDirection *= MoveSpeed;
		MoveDirection.y -= gravity * Time.deltaTime;
		myChar.Move(MoveDirection * Time.deltaTime);

		Vector3 targetDir = Target.position - transform.position;
		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);**/
		IsWalking = true;
		nav.SetDestination(Target.position);


	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			toNextPoint = true;
		} else if (other.tag == "Waypoint") {
			myAnim.SetBool ("IsWalking", false);
		}
			

	}
}
