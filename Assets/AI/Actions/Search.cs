using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class Search : RAINAction
{	
	public float _Angle = 40f;
	public float _Period = 1f;
	
	private float _Time;
	//private Transform myTransform;
	
	public override void Start(RAIN.Core.AI ai)
	{
		//Debug.Log("START!");
		//myTransform = ai.Body.transform;
		base.Start(ai);
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		//Debug.Log ("SEARCH!");
		_Time = _Time + Time.deltaTime;
		//Debug.Log(_Time);
		float phase = Mathf.Cos(_Time / _Period);
		//myTransform.localRotation = Quaternion.Euler( new Vector3(0, phase * _Angle, 0));
		ai.Kinematic.Rotation = new Vector3(0, phase * _Angle, 0);

		Animator animator = ai.Body.GetComponent<Animator>();
		animator.SetBool("run", false);


		GameObject seePlayer = ai.WorkingMemory.GetItem<GameObject>("varPlayer");
		//Debug.Log(seePlayer);
		if(seePlayer != null){
			bool currentSearchingness = ai.WorkingMemory.GetItem<bool>("isSearching");
			ai.WorkingMemory.SetItem<bool>("isSearching", !currentSearchingness);
			//Debug.Log ("I SEE HIM");
		}

		return ActionResult.SUCCESS;
	}
	
	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}