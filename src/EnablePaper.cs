using UnityEngine;
using System.Collections;

public class EnablePaper : MonoBehaviour {

	public CurWayPoint _curPaper;
	// Use this for initialization
	public int curPaper;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		curPaper = CurWayPoint.curWayPoint;
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			if(curPaper == 1){
				GameObject.Find("ICTCamPaper").GetComponent<MeshRenderer>().enabled = true;
				GameObject.Find("IICTPaper").GetComponent<MeshRenderer>().enabled = false;
				CurWayPoint.curWayPoint = 2;
			} else if(curPaper == 2){
				//GameObject.Find("MCamPaper").GetComponent<MeshRenderer>().enabled = true;
				GameObject.Find("MedPaper").GetComponent<MeshRenderer>().enabled = false;
				Destroy(GameObject.Find("Dis2"));
				CurWayPoint.curWayPoint = 3;
			} else if(curPaper == 3){
				GameObject.Find("PescarCamPaper").GetComponent<MeshRenderer>().enabled = true;
				GameObject.Find("PescarPaper").GetComponent<MeshRenderer>().enabled = false;
				CurWayPoint.curWayPoint = 4;
			} else if(curPaper == 4){
				GameObject.Find("QhCamPaper").GetComponent<MeshRenderer>().enabled = true;
				GameObject.Find("QhPaper").GetComponent<MeshRenderer>().enabled = false;
				CurWayPoint.curWayPoint = 5;
			} else if(curPaper == 5){
				GameObject.Find("CultuCamPaper").GetComponent<MeshRenderer>().enabled = true;
				GameObject.Find("CultuPaper").GetComponent<MeshRenderer>().enabled = false;
				CurWayPoint.curWayPoint = 6;
			}
		}
	}

	void OnTriggerExit (Collider other){
		if(other.tag == "Player"){
		if(curPaper == 2){
			Destroy(GameObject.Find("ICTCamPaper"));
			Destroy(GameObject.Find("Dis1"));
		} else if (curPaper == 3){
//			Destroy(GameObject.Find("MCamPaper").SetActive );
			//	GameObject.Find("MCamPaper").SetActive(false);
			//GameObject.Find("MCamPaper").GetComponent<MeshRenderer>().enabled = false;
//			Destroy(GameObject.Find("Dis2"));
		} else if (curPaper == 4){
			Destroy(GameObject.Find("PescarCamPaper"));
			Destroy(GameObject.Find("Dis3"));
			Destroy(GameObject.Find("Dis3v2"));
		} else if (curPaper == 5){
			Destroy(GameObject.Find("QhCamPaper"));
			Destroy(GameObject.Find("Dis4"));
		} else if (curPaper == 6){
			Destroy(GameObject.Find("CultuCamPaper"));
		}
		}
//		Destroy(gameObject);

	}
}
