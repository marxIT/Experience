using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

	private Transform player;
	private GameObject enemy;
	private Scare isDestroy;
	private string playertype;
//	private float distance;

	// Use this for initialization
	void Start () {
		playertype = PlayerPrefs.GetString ("playertype");
		player = GameObject.FindWithTag("Player").transform;
		enemy = GameObject.FindWithTag("Enemy");    
		isDestroy = GameObject.Find("Jump Scare").GetComponent<Scare>();

	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(player.position, transform.position) < 7F ) //this line
		{

			Destroy(enemy);
			Destroy(GameObject.FindWithTag("Direction"));
			isDestroy.isDestroy = true;
		}
	
	}

//	void SetDistance(){
//			switch (playertype) {
//		case "passive" : 
//			distance = 2F;
//			break;
//		case "normal" :
//			distance = 4F;
//			break;
//		case "agressive" :
//			distance = 7F;
//			break;
//		}
//	}

}
