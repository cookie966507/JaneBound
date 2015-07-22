using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class SetSearching : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
		bool currentSearchingness = ai.WorkingMemory.GetItem<bool>("isSearching");
		ai.WorkingMemory.SetItem<bool>("isSearching", !currentSearchingness);
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