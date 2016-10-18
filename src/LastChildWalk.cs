using UnityEngine;
using System.Collections;

public class LastChildWalk : MonoBehaviour {


	NavMeshAgent nav;
	Transform target;
	public static bool StartChase;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("LastPoint").transform;
		nav =transform.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(StartChase == true){
			nav.SetDestination(target.position);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			StartChase = true;
		}
	}
}
