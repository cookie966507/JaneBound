using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#region ERIC
namespace Assets.Scripts.Data
{
	public class SaveManager : DataHandler
	{
		public static SaveManager _instance;

		protected override void Init()
		{
			if(_instance == null)
			{
				DontDestroyOnLoad(this.gameObject);
				_instance = this;
			}
			else if(_instance != this)
			{
				Destroy(this.gameObject);
			}
		}

		public static void SaveAudio(float _sfxVol, float _musicVol)
		{
#if UNITY_WEBPLAYER
			PlayerPrefs.SetFloat(_audioHash + 0, _sfxVol);
			PlayerPrefs.SetFloat(_audioHash + 1, _musicVol);
#else
			BinaryFormatter _bf = new BinaryFormatter();
			FileStream _file = File.Create(_audioDataPath);

			AudioData _data = new AudioData(_sfxVol, _musicVol);

			_bf.Serialize(_file, _data);
			_file.Close();
#endif
		}

		public static void SaveVideo(int _resolutionIndex, int _qualityIndex, bool _fullscreen)
		{
#if UNITY_WEBPLAYER
			PlayerPrefs.SetInt(_videoHash + 0, _resolutionIndex);
			PlayerPrefs.SetInt(_videoHash + 1, _qualityIndex);
			int _full = _fullscreen ? 1 : 0;
			PlayerPrefs.SetInt(_videoHash + 2, _full);
#else
			BinaryFormatter _bf = new BinaryFormatter();
			FileStream _file = File.Create(_videoDataPath);
			
			VideoData _data = new VideoData(_resolutionIndex, _qualityIndex, _fullscreen);

			_bf.Serialize(_file, _data);
			_file.Close();
#endif
		}
	}
}
#endregion