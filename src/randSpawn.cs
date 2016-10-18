using UnityEngine;
using System.Collections;

public class randSpawn : MonoBehaviour {

	Vector3 spawnpositionbox;
	Vector3 spawnpositionAi;
	public GameObject _tbox;
	public GameObject _AI;
	int boxchild;
	int aichild;

	int tboxspawnpoint;
	int aispawnpoint;
	// Use this for initialization
	void Start () {


		GetTboxSpawns ();
		GetAiSpawns ();
//		spawnpositionbox = new Vector3 (Random.Range (45, 90), 0.223f, Random.Range(-10,10));
//		spawnpositionAi = new Vector3 (Random.Range (45, 90), 0.0f, Random.Range(-10,10));

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GetTboxSpawns(){
		boxchild = GameObject.FindWithTag ("BoxSpawnPoints").transform.childCount;
		tboxspawnpoint = (int) Random.Range (0F,(float) boxchild);
		spawnpositionbox = GameObject.FindWithTag ("BoxSpawnPoints").transform.GetChild (tboxspawnpoint).position;
		Instantiate (_tbox, spawnpositionbox, Quaternion.identity);

	}

	void GetAiSpawns(){
		aichild =  GameObject.FindWithTag ("AiSpawnPoints").transform.childCount;
		aispawnpoint = (int) Random.Range (0F,(float) aichild);
		spawnpositionAi = GameObject.FindWithTag ("AiSpawnPoints").transform.GetChild (aispawnpoint).position;
		Instantiate(_AI,spawnpositionAi,Quaternion.identity);

	}
}
