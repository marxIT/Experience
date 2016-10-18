using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CollectPaper : MonoBehaviour {

	public float DistancetoPaper = 0;
	public AudioClip paperaudio;
	public CursorLockMode wantedmode;
	Text pickup;
	Text exit;
	RawImage content;
	public bool hasRead = false;
	public Camera occam;

	// Use this for initialization
	void Start () {
//		Screen.lockCursor = true;
		content = GameObject.Find("Content").GetComponent<RawImage>();
		pickup = GameObject.Find("pickup").GetComponent<Text>();
		exit = GameObject.Find("exit").GetComponent<Text>();
		occam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

		Cursor.lockState = wantedmode; 
		Cursor.visible = (CursorLockMode.Locked != wantedmode);
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vec = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0.0f);
		Ray ray = occam.ScreenPointToRay(vec);
		RaycastHit hit;

			if (Physics.Raycast(ray, out hit, DistancetoPaper)) {

				if (hit.collider.gameObject.tag == "Paper") {
					pickup.enabled = true;
				if (Input.GetMouseButton(3) && pickup.enabled == true) {
					this.gameObject.GetComponent<CharacterController>().enabled = false;
					pickup.enabled = false;		
					AudioSource.PlayClipAtPoint(paperaudio,transform.position);
					Destroy(hit.collider.gameObject);
					exit.enabled = true;
					content.enabled = true;

						}
				} else {
				pickup.enabled = false;
				}

			}
			
		if (content.enabled == true) {
			if (Input.GetMouseButton(1)) {
				this.gameObject.GetComponent<CharacterController>().enabled = true;
				AudioSource.PlayClipAtPoint(paperaudio,transform.position);
				content.enabled = false;
				exit.enabled = false;

				hasRead = true;
				
			}
		

		}


		

	
	}
}
