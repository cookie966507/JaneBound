using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class Navigate : RAINAction
{

	private NavMeshAgent myAgent;

    public override void Start(RAIN.Core.AI ai)
    {
		myAgent = ai.Body.GetComponent<NavMeshAgent>();
		Vector3 myDestiny = ai.WorkingMemory.GetItem<Vector3>("destination");
		myAgent.SetDestination(myDestiny);

        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {

		Vector3 myDestiny = ai.WorkingMemory.GetItem<Vector3>("destination");

		Vector3 myPos = ai.Body.transform.position;

		if(myPos == myDestiny){
			Debug.Log ("REACHED DESTINATION");
			return ActionResult.SUCCESS;
		}


		Debug.Log("Destination " + myDestiny);
		Debug.Log("My Pos " + myPos);
		return ActionResult.RUNNING;
        
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}