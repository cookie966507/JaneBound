using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class StartChasing : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
		Debug.Log ("start chasing");
		ai.WorkingMemory.SetItem<bool>("hasDestination", true);
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