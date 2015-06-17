using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Camera
{
	public class ThirdPersonCameraFollow : MonoBehaviour
	{
		public float _smooth = 5f;
		private Transform _target;

		public GameObject _ragdoll;

		private bool _lookOnly = false;
		private float _smoothLook = 1f;

		//setting up events
		void OnEnable()
		{
			Player.PlayerLife.PlayerDie += WatchRagdoll;
		}
		
		void OnDisable()
		{
			Player.PlayerLife.PlayerDie -= WatchRagdoll;
		}

		void Start()
		{
			_target = GameObject.Find ("CameraPosition").transform;
		}
		
		void FixedUpdate ()
		{
			if(_lookOnly)
			{
				Quaternion _targetRotation = Quaternion.LookRotation(_target.position - this.transform.position);
				
				this.transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _smoothLook * Time.deltaTime);
			}
			else
			{
				transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _smooth);	
				transform.forward = Vector3.Lerp(transform.forward, _target.forward, Time.deltaTime * _smooth);
			}
		}

		public void WatchRagdoll()
		{
			_target = _ragdoll.transform;
			_lookOnly = true;
		}
	}
}
