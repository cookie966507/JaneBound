using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

namespace Assets.Scripts.Player
{
	[RAINAction]
	public class Caught : RAINAction
	{
	    public override void Start(RAIN.Core.AI ai)
	    {

			Debug.Log("Caught!");
			GameObject p = GameObject.FindGameObjectWithTag("Player");
			PlayerLife pl = p.GetComponent<PlayerLife>();
			pl.Health = 0f;

			//pm.EnableRagdoll();
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
}