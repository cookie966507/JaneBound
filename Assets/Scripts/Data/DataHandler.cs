using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#region ERIC
namespace Assets.Scripts.Data
{
	public abstract class DataHandler : MonoBehaviour
	{
#if UNITY_WEBPLAYER
		protected static string _audioHash = "JaneBound Audio";
		protected static string _videoHash = "JaneBound Video";
#else
		protected static string _audioDataPath = Application.persistentDataPath + "/Audio.dat";
		protected static string _videoDataPath = Application.persistentDataPath + "/Video.dat";
#endif

		void Awake()
		{
			Init();
		}

		protected abstract void Init();
	}

	[Serializable]
	public class VideoData
	{
		private int _resolutionIndex;
		private int _qualityIndex;
		private bool _fullScreen;

		public VideoData()
		{
			_resolutionIndex = 0;
			_qualityIndex = 0;
			_fullScreen = false;
		}

		public VideoData(int _resolutionIndex, int _qualityIndex, bool _fullScreen)
		{
			this._resolutionIndex = _resolutionIndex;
			this._qualityIndex = _qualityIndex;
			this._fullScreen = _fullScreen;
		}

		public int ResolutionIndex
		{
			get { return _resolutionIndex; }
			set { _resolutionIndex = value; }
		}
		public int QualityIndex
		{
			get { return _qualityIndex; }
			set { _qualityIndex = value; }
		}
		public bool Fullscreen
		{
			get { return _fullScreen; }
			set { _fullScreen = value; }
		}
	}

	[Serializable]
	public class AudioData
	{
		private float _sfxVol;
		private float _musicVol;

		public AudioData()
		{
			_sfxVol = 1f;
			_musicVol = 1f;
		}

		public AudioData(float _sfxVol, float _musicVol)
		{
			this._sfxVol = _sfxVol;
			this._musicVol = _musicVol;
		}
		
		public float SFXVol
		{
			get { return _sfxVol; }
			set { _sfxVol = value; }
		}
		public float MusicVol
		{
			get { return _musicVol; }
			set { _musicVol = value; }
		}
	}
}
#endregion