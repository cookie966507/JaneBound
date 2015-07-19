using UnityEngine;
using System.Collections;

#region ERIC
namespace Assets.Scripts.Player
{
	public class PlayerLife : PlayerControllerObject
	{
		private float _health = 100f;
		private bool _alive = true;

//		private float _resetLevelTimer = 0f;
//		private float _resetLevelDelay = 5f;

		//public delegate events to assign this controller to all listening components
		public delegate void PlayerDeath();
		public static event PlayerDeath PlayerDie;

		void Start ()
		{
			_health = 100f;
			_alive = true;
		}
		
		public override void Run()
		{
			if(_health <= 0)
			{
				if(_alive) PlayerDie();
				_alive = false;
			}
		}

		public override void FixedRun ()
		{

		}

		public float Health
		{
			get { return _health; }
			set { _health = value; }
		}
	}
}
#endregion