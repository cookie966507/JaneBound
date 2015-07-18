using UnityEngine;
using System.Collections;

#region ERIC
namespace Assets.Scripts.Util
{
	public class WinTrigger : MonoBehaviour
	{

		public delegate void PlayerWinGame();
		public static event PlayerWinGame PlayerWin;

		void OnTriggerEnter(Collider _col)
		{
			if(PlayerWin != null) PlayerWin();
		}
	}
}
#endregion