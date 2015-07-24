
/*
 * Navigate.cs
 * This script detects if the cop has reached his destination (the last place he saw the player).
 * If so, start searching
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

#region Chris



[RAINAction]
public class Navigate : RAINAction
{

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		Animator animator = ai.Body.GetComponent<Animator>();
		animator.SetBool("run", true);

		NavMeshAgent myAgent = ai.Body.GetComponent<NavMeshAgent>();
		Vector3 myDestiny = ai.WorkingMemory.GetItem<Vector3>("destination");
		Vector3 myPos = ai.Body.transform.position;

		float distance = Vector3.Distance(myPos, myDestiny);
		float myRadius = ai.Body.GetComponent<CapsuleCollider>().radius;

		//Debug.Log ("distance" + distance);
		//Debug.Log ("my rad" + myRadius);
		//Debug.Log ("-------------------------------------");

		//if the cop has reached his destination, search for a bit
		if(distance < 1 ){
			ai.WorkingMemory.SetItem<bool>("isSearching", true);
			//ai.WorkingMemory.SetItem<bool>("hasDestination", false);
			//Debug.Log ("MOVE ON TO SEARCHING");
			return ActionResult.SUCCESS;
		}

		return ActionResult.RUNNING; 
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}

#endregion