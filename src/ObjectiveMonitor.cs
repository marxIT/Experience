using UnityEngine;
using System.Collections;

public class ObjectiveMonitor : MonoBehaviour {
	float firstObject;
	float lastObject;
	float timeFinishLevel;
	float run;
	float walk;
	float timer;
	public PlayerInputs myPlayer;
	// Use this for initialization
	void Start () {
		myPlayer = GameObject.Find("playerInputs").GetComponent<PlayerInputs>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1 * Time.deltaTime;
		if(Input.GetKey(KeyCode.LeftShift)){
			run += 1 * Time.deltaTime;
		} else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)){
			walk += 1 * Time.deltaTime;
		}

		if(LastChildWalk.StartChase == true){
			timeFinishLevel = timer;
		}
		if(GameObject.Find("ICTCamPaper") != null){
				firstObject = timer;
		}
		if (GameObject.Find("CultuCamPaper") == null){
			lastObject = timer;
		}
		if(LastWalkDel.hasCollided == false){
			UpdateInputs();
		}


	}

	void UpdateInputs(){
		myPlayer.timeSpentRunning = run;
		myPlayer.timeSpentWalking = walk;
		myPlayer.timeToCollectFirstPaper = firstObject;
		myPlayer.timeToCollectLastPaper = lastObject;
		myPlayer.timeTofinishLevel = timeFinishLevel;
	}
}
