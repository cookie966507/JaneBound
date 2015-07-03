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
				Debug.Log("Too many load managers");
				Destroy(this.gameObject);
			}
		}

		public static AudioData LoadAudio()
		{
#if UNITY_WEBPLAYER
			AudioData _data = new AudioData();
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

				AudioData _data = (AudioData)_bf.Deserialize(_file);

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
	}
}
#endregion