using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Hazards
{
	public class SlipperyAreaSetup : MonoBehaviour
	{
		private Transform _point1;
		private Transform _point2;

		private Transform _colliderObject;

		void Start()
		{
			_point1 = this.transform.FindChild("Point_1");
			_point2 = this.transform.FindChild("Point_2");

			_colliderObject = this.transform.FindChild("Slip_Trigger");

			RaycastHit _hit;
			if(Physics.Raycast(_point1.position, Vector3.down,out _hit, Mathf.Infinity, (1 << LayerMask.NameToLayer("Ground"))))
			{
				_point1.position = _hit.point;
			}
			else
			{
				Debug.LogError("Point 1 is not above ground!");
			}
			if(Physics.Raycast(_point2.position, Vector3.down, out _hit, Mathf.Infinity, (1 << LayerMask.NameToLayer("Ground"))))
			{
				_point2.position = _hit.point;
			}
			else
			{
				Debug.LogError("Point 2 is not above ground!");
			}

			float _size = Mathf.Abs(Vector3.Distance(_point1.position, _point2.position));
			Vector3 _midPoint = (_point2.position + _point1.position) * 0.5f;

			_colliderObject.position = _midPoint;
			_colliderObject.LookAt(_point2);
			_colliderObject.localScale = new Vector3(1f, 0.1f, _size);
		}
	}
}
