using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

#region Sabrina
[RAINAction]
public class DanceAction : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
	{
		float danceTime = (float) ai.WorkingMemory.GetItem ("danceTime");
		
		danceTime += Time.deltaTime;
		
		//Debug.Log(danceTime);
		
		ai.WorkingMemory.SetItem ("danceTime", danceTime);

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