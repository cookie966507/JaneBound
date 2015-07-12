#region SHAWN
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class ZZAction : RAINAction
{
	public override void Start(RAIN.Core.AI ai)
	{
		Sleep sleep = GameObject.Instantiate (ai.WorkingMemory.GetItem ("sleep") as GameObject).GetComponent<Sleep> ();
		float yOffset = ai.Body.GetComponent<CapsuleCollider>().bounds.size.y;
		yOffset += 1.2f;
		Vector3 copPosition = ai.Body.transform.position;
		sleep.transform.position = new Vector3 (copPosition.x,
		                                        copPosition.y + yOffset,
		                                        copPosition.z);
		sleep.transform.SetParent(ai.Body.transform,true);
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