using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class Scan : RAINAction
{	
	public float _Angle = 15f;
	public float _Period = 5f;

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

		_Time = _Time + Time.deltaTime;
		//Debug.Log(_Time);
		float phase = Mathf.Sin(_Time / _Period);
		//myTransform.localRotation = Quaternion.Euler( new Vector3(0, phase * _Angle, 0));
		ai.Kinematic.Rotation = new Vector3(0, phase * _Angle, 0);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}