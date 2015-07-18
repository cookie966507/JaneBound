using UnityEngine;
using System.Collections;

public class CreditsMoveScript : MonoBehaviour {

	// Use this for initialization
	Transform[] allChildren;
	float sign;
	float lastPos;
	//int i;
	void Start () {
		allChildren = GetComponentsInChildren<Transform>();
		sign = 1;
		lastPos = allChildren[allChildren.Length-1].transform.position.x;
//		origPos = new Vector3[5];
//		foreach (Transform child in transform)
//		{
//			origPos[i] = child.transform.position;
//			i++;
//		}

	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (allChildren[allChildren.Length-1].transform.position.x);
		if(allChildren[allChildren.Length-1].transform.position.x <-20)
		{
			sign=sign*-1;
		}
		if(allChildren[allChildren.Length-1].transform.position.x > lastPos)
		{
			sign=sign*-1;
		}
		Debug.Log(sign);
		foreach (Transform child in transform)
		{


			Vector3 shift = new Vector3(0.1f,0,0);
			Vector3 newPos = child.transform.position - sign*shift;
			child.transform.position = newPos;

			// do whatever you want with child transform object here
		}
	}
}
