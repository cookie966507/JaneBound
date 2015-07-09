using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;


namespace Assets.Scripts
{
	[RAINAction]
	public class CabbageMotion : RAINAction
	{
		CabbageThrow ct;
	    public override void Start(RAIN.Core.AI ai)
	    {

			GameObject p = GameObject.FindGameObjectWithTag("Player");
			GameObject cabbageGuy = GameObject.Find("CabbageGuy");
			Player.PlayerMove pm = p.GetComponent<Player.PlayerMove>();
			ct = cabbageGuy.GetComponent<CabbageThrow>();

			Vector3 predictVector = p.transform.position + p.transform.forward.normalized*1f*pm.maxSpeed*(pm.animator.GetFloat("Speed")/2);

			Vector3 predicPosDif =  predictVector - cabbageGuy.transform.position;
			ct.cabbage_force = predicPosDif.magnitude*68;
			ct.predictVector = predicPosDif.normalized;

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