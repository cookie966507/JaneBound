using UnityEngine;
using System.Collections;

public class BubbleColide : MonoBehaviour {

	private Rigidbody myBody;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		myBody = this.GetComponent<Rigidbody>();
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag != "Player"){
			if(myBody)
			{
				print ("bubble collide");
				myBody.isKinematic = true;
				Destroy (myBody);
			}
		}
	}
}
