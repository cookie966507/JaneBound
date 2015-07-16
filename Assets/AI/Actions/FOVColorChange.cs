using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class FOVColorChange : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
		//Change the FOV Color
		FOV2DVisionCone FOV = ai.Body.transform.Find("FOV2D").GetComponent<FOV2DVisionCone>();
		FOV.status = FOV2DVisionCone.Status.Idle;
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