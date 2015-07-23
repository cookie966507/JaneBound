using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class SetDestination : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
		//Navigator nav = ai.Body.transform.GetComponent<Navigator>();
		Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		//Debug.Log("SET DESTINATION");
		ai.WorkingMemory.SetItem<Vector3>("destination", playerPos);
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}