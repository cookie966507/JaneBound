using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Hazards
{
	public class DeathPit : MonoBehaviour
	{
		void OnTriggerEnter(Collider _col)
		{
			if(_col.tag.Equals("Player"))
			{
				_col.GetComponent<Player.PlayerLife>().Health = 0f;
			}
		}
	}
}
