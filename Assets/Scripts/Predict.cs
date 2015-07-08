using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.BehaviorTrees;
using RAIN.Motion;

namespace Assets.Scripts.Player
{
	[RAINAction]
	public class Predict : RAINAction
	{

		MoveLookTarget mlt = new MoveLookTarget();

		Vector3 target = new Vector3();

		public override void Start(RAIN.Core.AI ai)
		{

			//t.position.Set(0,0,0);//t.position.x*10,t.position.y,t.position.z*10);
			//mlt.TransformTarget = t;
			GameObject p = GameObject.FindGameObjectWithTag("Player");
			PlayerMove pm = p.GetComponent<PlayerMove>();
			target = p.transform.position + 5*p.transform.forward*pm.animator.GetFloat("Speed");
			//target.Set (0,0,0);
			mlt.VectorTarget = target;
			Debug.Log("Start");
			ai.WorkingMemory.SetItem<MoveLookTarget>("directionVector", mlt);
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