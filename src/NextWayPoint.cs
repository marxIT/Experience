using UnityEngine;
using System.Collections;

public class NextWayPoint : MonoBehaviour {


	public static int curPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		curPoint = CurWayPoint.ictCurPoint;
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Enemy"){
		if(curPoint == 1){
			CurWayPoint.ictCurPoint = 2;
				Patrol.toNextPoint = false;
		} else if(curPoint == 2){
			CurWayPoint.ictCurPoint = 3;
				Patrol.toNextPoint = false;
		} else if(curPoint == 3){
				CurWayPoint.ictCurPoint = 4;
				Patrol.toNextPoint = false;
		} else if(curPoint == 4){
				CurWayPoint.ictCurPoint = 5;
				Patrol.toNextPoint = false;
		} else if(curPoint == 5){
				CurWayPoint.ictCurPoint = 6;
				Patrol.toNextPoint = false;
		} else if(curPoint == 6){
				CurWayPoint.ictCurPoint = 7;
				Patrol.toNextPoint = false;
		} else if(curPoint == 7){
				CurWayPoint.ictCurPoint = 8;
				Patrol.toNextPoint = false;
		} else if(curPoint == 8){
				CurWayPoint.ictCurPoint = 9;
				Patrol.toNextPoint = false;
			} else if(curPoint == 9){
				CurWayPoint.ictCurPoint = 10;
				Patrol.toNextPoint = false;
				Destroy(GameObject.Find("ICTMonster"));
			}
			//transform.GetComponent<MeshRenderer>().enabled = false;
			Destroy(gameObject);
		}
	}
}
