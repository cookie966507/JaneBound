using UnityEngine;
using System.Collections;

/*
 * This class wil manage all the player's components,
 * such as movement, data , etc
 */
namespace Assets.Scripts.Player
{
	public class PlayerController : MonoBehaviour
	{
		//componenets to manage
		private PlayerMovement _movement;
		private PlayerLife _life;

		//public delegate events to assign this controller to all listening components
		public delegate void AssignmentEvent(PlayerController _controller);
		public static event AssignmentEvent AssignController;

		void Start()
		{
			//init all componenets
			this.InitializePlayerComponents();
		}
		void Update()
		{
			//if game is not paused
			if(!Data.GameManager.IsPaused)
			{
				//run all components
				_life.Run();
				if(_life.Health > 0)
					_movement.Run();
			}
		}

		void FixedUpdate()
		{
			//if game is not paused
			if(!Data.GameManager.IsPaused)
			{
				//run all fixed components for physics
				if(_life.Health > 0)
					_movement.FixedRun();
			}
		}

		//assigning references
		private void InitializePlayerComponents()
		{
			//get all components to manage
			_movement = this.GetComponent<PlayerMovement>();
			_life = this.GetComponent<PlayerLife>();

			//tell all components this is their controller
			AssignController(this);
		}

		public PlayerMovement Movement
		{
			get { return _movement; }
		}
		public PlayerLife Life
		{
			get { return _life; }
		}
	}
}
