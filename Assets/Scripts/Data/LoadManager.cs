using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#region ERIC
namespace Assets.Scripts.Data
{
	public class LoadManager : DataHandler
	{
		private static LoadManager _instance;

		protected override void Init()
		{
			if(_instance == null)
			{
				DontDestroyOnLoad(this.gameObject);
				_instance = this;
			}
			else if (_instance != this)
			{
				Destroy(this.gameObject);
			}
		}

		public static AudioData LoadAudio()
		{
			AudioData _data = new AudioData();
#if UNITY_WEBPLAYER

			if(PlayerPrefs.HasKey(_audioHash + 0))
			{
				_data.SFXVol = PlayerPrefs.GetFloat(_audioHash + 0);
				_data.MusicVol = PlayerPrefs.GetFloat(_audioHash + 1);
			}
			else
			{
				SaveManager.SaveAudio(1f, 1f);
			}
			return _data;
#else

			if(File.Exists(_audioDataPath))
			{
				BinaryFormatter _bf = new BinaryFormatter();
				FileStream _file = File.Open(_audioDataPath, FileMode.Open);

				_data = (AudioData)_bf.Deserialize(_file);

				_file.Close();

				return _data;
			}
			else
			{
				AudioData _newData = new AudioData();
				SaveManager.SaveAudio(1f, 1f);
				return _newData;
			}
#endif
		}

		public static VideoData LoadVideo()
		{
			VideoData _data = new VideoData();
#if UNITY_WEBPLAYER

			if(PlayerPrefs.HasKey(_videoHash + 0))
			{
				_data.ResolutionIndex = PlayerPrefs.GetInt(_videoHash + 0);
				_data.QualityIndex = PlayerPrefs.GetInt(_videoHash + 1);
				int _full = PlayerPrefs.GetInt(_videoHash + 2);
				_data.Fullscreen = (_full == 1) ? true : false;
			}
			else
			{
				SaveManager.SaveVideo(_data.ResolutionIndex, _data.QualityIndex, _data.Fullscreen);
			}
			return _data;
#else

			if(File.Exists(_videoDataPath))
			{
				BinaryFormatter _bf = new BinaryFormatter();
				FileStream _file = File.Open(_videoDataPath, FileMode.Open);
				
				_data = (VideoData)_bf.Deserialize(_file);
				
				_file.Close();
				
				return _data;
			}
			else
			{
				VideoData _newData = new VideoData();
				SaveManager.SaveVideo(_data.ResolutionIndex, _data.QualityIndex, _data.Fullscreen);
				return _newData;
			}
#endif
		}
	}
}
#endregion