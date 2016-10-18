using UnityEngine;
using System.Collections;

public class QhChase : MonoBehaviour {

	Transform target;
	NavMeshAgent nav;
	public static bool StartChaseQh;
	AudioSource aud;
	// Use this for initialization
	void Start () {
		target = GameObject.Find("MainPlayer").transform;
		nav = transform.GetComponent<NavMeshAgent>();
		aud = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(StartChaseQh == true){
			aud.mute = false;
			nav.SetDestination(target.position);
		}
	}
}
