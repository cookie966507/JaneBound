using UnityEngine;
using System.Collections;
using Assets.Scripts.Player;
using Assets.Scripts.Data;
namespace Assets.Scripts.Player
{
	//by: Shawn Kim
	public class Footstep : PlayerControllerObject
	{
		#region ERIC
		public Transform _leftFoot;
		public Transform _rightFoot;

		private AudioSource _leftAudioSource;
		private AudioSource _rightAudioSource;

		private GameObject _stepParticles;

		private string _prefabsPath;

		void Awake()
		{
			_leftAudioSource = _leftFoot.GetComponent<AudioSource>();
			_rightAudioSource = _rightFoot.GetComponent<AudioSource>();

			_prefabsPath = "Prefabs/ParticleEffects/";

			_stepParticles = (GameObject)Resources.Load(_prefabsPath + "Dust");
		}

		public override void Run ()
		{
			//we will use this to determine what the player is standing on to change
			// audio and particles
		}

		public override void FixedRun ()
		{
			throw new System.NotImplementedException ();
		}

		public void LeftFootStep()
		{
			if(Controller.MovementComponent.grounded)
			{
				GameObject.Instantiate(_stepParticles, _leftFoot.position, _leftFoot.rotation);
				SoundManager.PlaySFX(_leftAudioSource);
			}
		}

		public void RightFootStep()
		{
			if(Controller.MovementComponent.grounded)
			{
				GameObject.Instantiate(_stepParticles, _rightFoot.position, _rightFoot.rotation);
				SoundManager.PlaySFX(_rightAudioSource);
			}
		}
		#endregion
	}
}
