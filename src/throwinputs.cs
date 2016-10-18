using UnityEngine;
using System.Collections;

public class throwinputs : MonoBehaviour {

	PlayerInputs playerint;
	ForwardPass fpass;
	public bool passed;
	// Use this for initialization
	void Start () {
	
		playerint = GameObject.Find("playerInputs").GetComponent<PlayerInputs>();
		fpass = GameObject.Find("Backpro").GetComponent<ForwardPass>();
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "player") {
			fpass.feedin1 = new double[]{playerint.timeTofinishLevel,playerint.timeToCollectFirstPaper,playerint.timeSpentRunning,playerint.timeSpentWalking,playerint.timeToCollectLastPaper};
			passed = true;
		}
	}
}
