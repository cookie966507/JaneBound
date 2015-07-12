using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Navigation;
using RAIN.Navigation.Graph;

[RAINAction]
public class ChooseRandom : RAINAction
{
	private RAIN.Navigation.Targets.NavigationTarget _target;
	
	public ChooseRandom()
	{
		actionName = "ChooseRandom";
	}
	
	public override void Start(AI ai)
	{
		_target = NavigationManager.Instance.GetNavigationTarget("PointPosition");
		
		base.Start(ai);
	}
	
	public override ActionResult Execute(AI ai)
	{
		Vector3 loc = Vector3.zero;
		
		List<RAINNavigationGraph> found = new List<RAINNavigationGraph>();
		do
		{
			loc = new Vector3(ai.Kinematic.Position.x + Random.Range(-5f, 5f),
			                  ai.Kinematic.Position.y,
			                  ai.Kinematic.Position.z + Random.Range(-5f, 5f));
			
			setFlushToSurface(loc);
			
			found = NavigationManager.Instance.GraphsForPoints(
				ai.Kinematic.Position, 
				_target.Position, 
				ai.Motor.StepUpHeight, 
				NavigationManager.GraphType.Navmesh, 
				((BasicNavigator)ai.Navigator).GraphTags);
			
		} while ((Vector3.Distance(ai.Kinematic.Position, _target.Position) < 2f) || (found.Count == 0));
		
		ai.WorkingMemory.SetItem<Vector3>("wanderTarget", _target.Position);
		Debug.Log ("wander Target is " + _target.Position);
		
		return ActionResult.SUCCESS;
	}
	
	public override void Stop(AI ai)
	{
		base.Stop(ai);
	}
	
	private void setFlushToSurface(Vector3 targetPosition)
	{
		var v = RAIN.Utility.MathUtils.CastToCollider(targetPosition, Vector3.down, 0f, 1000f);
		var vv = v - _target.Position;
		if(vv.magnitude > 0f)
		{
			_target.Position = v;
		}
	}
}