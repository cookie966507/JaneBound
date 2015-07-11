using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#region ERIC
namespace Assets.Scripts.Data
{
	/*
	 * Manager for controlling sound.
	 * All sounds/music should come through here
	 */
	public class SoundManager : MonoBehaviour
	{
		//reference to the sound manager
		public static SoundManager _instance;

		//volume of the audio types
		private static float _sfxVol = 1f;
		private static float _musicVol = 1f;

		//lists to keep references to the different AudioSources
		private static List<AudioSource> _sfxSources;
		private static List<AudioSource> _musicSources;

		//setting up events
		void OnEnable()
		{
			GameManager.GamePause += PauseAudio;
			GameManager.GameUnpause += UnpauseAudio;
		}
		
		void OnDisable()
		{
			GameManager.GamePause -= PauseAudio;
			GameManager.GameUnpause -= UnpauseAudio;
		}

		void Awake()
		{
			//if the manager is null
			if(_instance == null)
			{
				//init the manager
				DontDestroyOnLoad(gameObject);
				_instance = this;
				_sfxSources = new List<AudioSource>();
				_musicSources = new List<AudioSource>();

				AudioData _data = LoadManager.LoadAudio();
				_musicVol = _data.MusicVol;
				_sfxVol = _data.SFXVol;
			}
			//too many sound managers
			else if(_instance != this)
			{
				Destroy(gameObject);
			}
		}

		void OnLevelWasLoaded(int i)
		{
			_musicSources.Clear();
			_sfxSources.Clear();
		}

		void Update()
		{
			if(!GameManager.InSuspendedState)
			{
				//go through the audio sources
				for(int i = 0; i < _sfxSources.Count; i++)
				{
					//if the source is finished playing
					if(!_sfxSources[i].isPlaying)
					{
						//remove the reference because we are done with it (tempList will remove it)
						_sfxSources.RemoveAt(i);
						//decrement i
						i--;
					}
				}

				//same for the music
				for(int i = 0; i < _musicSources.Count; i++)
				{
					if(!_musicSources[i].isPlaying)
					{
						_musicSources.RemoveAt(i);
						i--;
					}
				}
			}
		}

		//function for playing sfx
		public static void PlaySFX(AudioSource _audio)
		{
			if(!_sfxSources.Contains(_audio))
			   {
				_audio.volume = _sfxVol;

				_sfxSources.Add(_audio);
				_audio.Play();
			}
		}

		//function for playing music
		public static void PlayMusic(AudioSource _audio)
		{
			if(!_musicSources.Contains(_audio))
			{
				_audio.volume = _musicVol;

				_musicSources.Add(_audio);
				_audio.Play();
			}
		}

		//update the sfx vol based on slider
		public static void SliderSFX(float _vol)
		{
			_sfxVol = _vol;

			for(int i = 0; i < _sfxSources.Count; i++)
			{
				_sfxSources[i].volume = _sfxVol;
			}
		}

		//update the music vol based on slider
		public static void SliderMusic(float _vol)
		{
			_musicVol = _vol;

			for(int i = 0; i < _musicSources.Count; i++)
			{
				_musicSources[i].volume = _musicVol;
			}
		}

		public void PauseAudio()
		{
			for(int i = 0; i < _musicSources.Count; i++)
			{
				_musicSources[i].Pause();
			}
			for(int i = 0; i < _sfxSources.Count; i++)
			{
				_sfxSources[i].Pause();
			}
		}

		public void UnpauseAudio()
		{
			for(int i = 0; i < _musicSources.Count; i++)
			{
				_musicSources[i].Play();
			}
			for(int i = 0; i < _sfxSources.Count; i++)
			{
				_sfxSources[i].Play();
			}
		}
	}
}
#endregion