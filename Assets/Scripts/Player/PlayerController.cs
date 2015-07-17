using UnityEngine;
using System.Collections;

#region ERIC
/*
 * This class wil manage all the player's components,
 * such as movement, data , etc
 */
namespace Assets.Scripts.Player
{
	public class PlayerController : MonoBehaviour
	{
		//componenets to manage
		private PlayerMove _movement;
		private PlayerLife _life;
		private PushPull _pushPull;
		private Footstep _footStep;

		//used for particle effects
		private bool lastState = true;
		private bool currentState;
		public ParticleSystem particle; 



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
			if(!Data.GameManager.InSuspendedState)
			{
				//run all components
				_life.Run();
				if(_life.Health > 0)
				{
					_movement.Run();
					_footStep.Run();
				}
				#endregion

				#region Sabrina
				currentState = _movement.grounded;

				if (Time.time > 3.0 && !lastState && currentState && !_movement.landedOnBubble) {
					particle.Play();
				}


				lastState = _movement.grounded;
				#endregion
			}
		}

		#region Eric
		void FixedUpdate()
		{
			//if game is not paused
			if(!Data.GameManager.InSuspendedState)
			{
				//run all fixed components for physics
				if(_life.Health > 0)
				{
					_movement.FixedRun();
					_pushPull.FixedRun();
				}
			}
		}

		//assigning references
		private void InitializePlayerComponents()
		{
			//get all components to manage
			_movement = this.GetComponent<PlayerMove>();
			_life = this.GetComponent<PlayerLife>();
			_pushPull = this.GetComponent<PushPull>();
			_footStep = this.GetComponentInChildren<Footstep>();


			//tell all components this is their controller
			AssignController(this);
		}

		public PlayerMove MovementComponent
		{
			get { return _movement; }
		}
		public PlayerLife LifeComponent
		{
			get { return _life; }
		}
		public PushPull PushPullComponent
		{
			get { return _pushPull; }
		}
		public Footstep FootStepComponent
		{
			get { return _footStep; }
		}
	}
}
#endregion