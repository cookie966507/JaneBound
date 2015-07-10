using UnityEngine;
using System.Collections;
using Assets.Scripts.Player;
using Assets.Scripts.Data;
namespace Assets.Scripts.Player
{
	//by: Shawn Kim
	public class EnemyFootstep : MonoBehaviour
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

		public void LeftFootStep()
		{
			GameObject.Instantiate(_stepParticles, _leftFoot.position, _leftFoot.rotation);
			SoundManager.PlaySFX(_leftAudioSource);
		}

		public void RightFootStep()
		{
			GameObject.Instantiate(_stepParticles, _rightFoot.position, _rightFoot.rotation);
			SoundManager.PlaySFX(_rightAudioSource);
		}
		#endregion
	}
}
