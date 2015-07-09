using UnityEngine;
using System.Collections;

public class CabbageThrow : MonoBehaviour {
	public float cabbage_force = 1000;
	public float armHeight = 5;
	public Vector3 predictVector;
	void Start () {

		predictVector = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

	
	}


	void ThrowCabbage()
	{
		Vector3 throwPosition = transform.position;
		throwPosition.Set(transform.position.x,transform.position.y+armHeight,transform.position.z);
		//Debug.Log (throwPosition);
		GameObject cabbage = (GameObject)GameObject.Instantiate(Resources.Load("Food_Watermelon"),throwPosition,Quaternion.identity);
		Rigidbody cabbage_body = cabbage.GetComponent<Rigidbody>();
		cabbage_body.AddForce(predictVector*cabbage_force);


	}
}
