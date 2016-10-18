using UnityEngine;
using System.Collections;

public class WaypointIICT : MonoBehaviour {

	public int curWaypoint;
	Vector3 nextPath;
	// Use this for initialization
	void Start () {
		nextPath = GameObject.Find("1").transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
