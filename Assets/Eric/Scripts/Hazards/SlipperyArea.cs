using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Hazards
{
	public class SlipperyArea : MonoBehaviour
	{
		void OnTriggerEnter(Collider _col)
		{
			if(_col.tag.Equals("Player"))
			{
				_col.GetComponent<Player.PlayerMovement>().Slip(this.transform.forward);
			}
		}
	}
}
