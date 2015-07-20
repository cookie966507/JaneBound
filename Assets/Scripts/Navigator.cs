using UnityEngine;
using System.Collections;

public class Navigator : MonoBehaviour {

	public Vector3 myVector;
	public bool hasDestination = true;
	public Transform destination;
	private NavMeshAgent myAgent;

	// Use this for initialization
	void Start () {
		myAgent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(hasDestination){
			myAgent.SetDestination(myVector);
		}
	}
}
