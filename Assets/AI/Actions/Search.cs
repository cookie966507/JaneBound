
/*
 * SEARCH.cs
 * Rain AI action, executed when the NPC cannot see the player but knows the last place they were seen.
 * AI scans left and right at the last known position.
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

#region Chris

[RAINAction]
public class Search : RAINAction
{	
	public float _Angle = 40f;
	public float _Period = 1f;
	
	private float _Time;
	//private Transform myTransform;
	
	public override void Start(RAIN.Core.AI ai)
	{
		//change fov color to idle
		FOV2DVisionCone FOV = ai.Body.transform.Find("FOV2D").GetComponent<FOV2DVisionCone>();
		FOV.status = FOV2DVisionCone.Status.Idle;

		base.Start(ai);
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		_Time = _Time + Time.deltaTime;
		float phase = Mathf.Cos(_Time / _Period);
		ai.Kinematic.Rotation = new Vector3(0, phase * _Angle, 0);

		Animator animator = ai.Body.GetComponent<Animator>();
		animator.SetBool("run", false);


		GameObject seePlayer = ai.WorkingMemory.GetItem<GameObject>("varPlayer");

		if(seePlayer != null){
			bool currentSearchingness = ai.WorkingMemory.GetItem<bool>("isSearching");
			ai.WorkingMemory.SetItem<bool>("isSearching", !currentSearchingness);
		}

		return ActionResult.SUCCESS;
	}
	
	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}

#endregion