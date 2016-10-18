using UnityEngine;
using System.Collections;

public class NavigationScript : MonoBehaviour {
	Transform target;
	NavMeshAgent nav;
	public static bool StartChase;
	// Use this for initialization
	void Start () {
		target = GameObject.Find("MainPlayer").transform;
		nav = transform.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(StartChase == true){
			nav.SetDestination(target.position);
		}
	}


}
