using UnityEngine;
using System.Collections;

public class AI2 : Pathfinding {
	
	public Transform direction;
	private CharacterController controller;
	private bool newPath = true;
	private bool moving = false;
	private GameObject[] AIList;
	private float speed = 7F;
	private string playertype;

	void Start () 
	{
		playertype = PlayerPrefs.GetString ("playertype");

		AIList = GameObject.FindGameObjectsWithTag("Enemy");
		direction = GameObject.Find("direction").transform;
//		SetSpeed ();
	}
	
	void Update () 
	{
		if (Vector3.Distance(direction.position, transform.position) > 1F && !moving) //this line
		{
			if (newPath)
			{
				StartCoroutine(NewPath());
			}
			moving = true;
		}
		else if (Vector3.Distance(direction.position, transform.position) < 1F)
		{
			//Stop!
		}
		else if (Vector3.Distance(direction.position, transform.position) > 1F && moving)// this line
		{
			if (Path.Count > 0)
			{
				if (Vector3.Distance(direction.position, Path[Path.Count - 1]) > 1F)
				{
					StartCoroutine(NewPath());
				}
			}
			else
			{
				if (newPath)
				{
					StartCoroutine(NewPath());
				}
			}
			//Move the ai towards the player
			MoveMethod();
		}
		else
		{
			moving = false;
		}
	}
	
	IEnumerator NewPath()
	{
		newPath = false;
		FindPath(transform.position, direction.position);
		yield return new WaitForSeconds(1F);
		newPath = true;
	}
	
	
	private void MoveMethod()
	{
		if (Path.Count > 0)
		{
			Vector3 direction = (Path[0] - transform.position).normalized;
			
			foreach (GameObject g in AIList)
			{
				if(Vector3.Distance(g.transform.position, transform.position) < 1F)
				{
					Vector3 dir = (transform.position - g.transform.position).normalized;
					dir.Set(dir.x, 0, dir.z);
					direction += 0.2F * dir;
				}
			}
			
			direction.Normalize();
			
			
			transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * speed);
			
			if (transform.position.x < Path[0].x + 0.4F && transform.position.x > Path[0].x - 0.4F && transform.position.z > Path[0].z - 0.4F && transform.position.z < Path[0].z + 0.4F)
			{
				Path.RemoveAt(0);
			}
			
			RaycastHit[] hit = Physics.RaycastAll(transform.position + (Vector3.up * 20F), Vector3.down, 100);
			float maxY = -Mathf.Infinity;
			foreach (RaycastHit h in hit)
			{
				if (h.transform.tag == "Untagged")
				{
					if (maxY < h.point.y)
					{
						maxY = h.point.y;
					}
				}
			}
			if (maxY > -100)
			{
				transform.position = new Vector3(transform.position.x, maxY + 0F, transform.position.z);
			}

		}
	}

//	void SetSpeed(){
//		switch (playertype) {
//		case "passive":
//			speed = 3F;
//			break;
//
//		case "normal":
//			speed = 5F;
//			break;
//		case "agressive":
//			speed = 7f;
//			break;
//		}
//
//	}
}
