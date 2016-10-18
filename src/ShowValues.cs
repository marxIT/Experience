using UnityEngine;
using System.Collections;

public class ShowValues : MonoBehaviour {

	public int CurValue;
	public CurWayPoint _curWayPoint;
	public bool isChasing;
	public bool isThrowable;
	public bool chase2;
	public bool collisionCheck;
	public int nextPoint;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CurValue = CurWayPoint.curWayPoint;
		isChasing = NavigationScript.StartChase;
		isThrowable = ThrowObject.throwable;
		chase2 = QhChase.StartChaseQh;
		collisionCheck = LastWalkDel.hasCollided;
		nextPoint = NextWayPoint.curPoint;

	}
}
