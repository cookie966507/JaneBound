
/*
 * SetDestination.cs
 * Rain AI action, sets the NPCs destination to where the player is.
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

#region Chris

[RAINAction]
public class SetDestination : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
		//set the FOV to ALERTS
		FOV2DVisionCone FOV = ai.Body.transform.Find("FOV2D").GetComponent<FOV2DVisionCone>();
		FOV.status = FOV2DVisionCone.Status.Alert;

		Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
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

#endregion