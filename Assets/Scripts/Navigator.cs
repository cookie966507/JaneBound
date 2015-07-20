using UnityEngine;
using System.Collections;

public class Navigator : MonoBehaviour {
	
	public Transform destination;
	private NavMeshAgent myAgent;

	// Use this for initialization
	void Start () {
		myAgent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(destination != null){
			myAgent.SetDestination(destination.position);
			print ("LETS GO");
		}
	}
}
