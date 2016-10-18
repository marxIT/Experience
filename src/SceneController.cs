using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	public	GameObject HitmapEasy;
	public GameObject PlayerSpawnEasy;
	public GameObject AiSpawnEasy;
	public GameObject BoxSpawnEasy;
	public GameObject Easy;
	public GameObject Player;
	public GameObject EasyRandSpawn;
	Vector3 playereasy;
	// Use this for initialization
	void Start () {
		playereasy = new Vector3 (89.4f, 0f, 90f);

		EasyLevel ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void EasyLevel(){
		Instantiate (Easy, Vector3.zero, Quaternion.identity);
		Instantiate (HitmapEasy, Vector3.zero, Quaternion.identity);
		Instantiate (AiSpawnEasy, Vector3.zero, Quaternion.identity);
		Instantiate (BoxSpawnEasy, Vector3.zero, Quaternion.identity);
		Instantiate (PlayerSpawnEasy, playereasy, Quaternion.identity);
		Instantiate (Player, PlayerSpawnEasy.transform.position, Quaternion.identity);
		Instantiate (EasyRandSpawn, Vector3.zero, Quaternion.identity);



	}
}
