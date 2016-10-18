using UnityEngine;
using System.Collections;

public class lookatDirection : MonoBehaviour {

	private GameObject direction;
	// Use this for initialization
	void Start () {
		direction = GameObject.Find("direction");
	
	}
	
	// Update is called once per frame
	void Update () {
			
		transform.LookAt(direction.transform);
	}
}
