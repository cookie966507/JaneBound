using UnityEngine;
using System.Collections;

public class CabbageThrow : MonoBehaviour {
	float cabbage_force = 1000;

	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

	
	}
	void ThrowCabbage()
	{
		Vector3 throwPosition = transform.position;
		throwPosition.Set(transform.position.x,transform.position.y+5,transform.position.z);
		Debug.Log (throwPosition);
		GameObject cabbage = (GameObject)GameObject.Instantiate(Resources.Load("Food_Watermelon"),throwPosition,Quaternion.identity);
		Debug.Log ("Created");
		Rigidbody cabbage_body = cabbage.GetComponent<Rigidbody>();
		cabbage_body.AddForce(transform.forward * cabbage_force);
	

	}
}
