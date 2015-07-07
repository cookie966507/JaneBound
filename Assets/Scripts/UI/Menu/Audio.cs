using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Data;

namespace Assets.Scripts.UI.Menu
{
    class Audio : MonoBehaviour
    {
        public Slider _music;
        public Slider _sfx;

        void Start()
        {
			_music = this.transform.Find("Music").GetComponent<Slider>();
			_sfx = this.transform.Find("SFX").GetComponent<Slider>();

			AudioData _data = LoadManager.LoadAudio();

			_music.value = _data.MusicVol;
            _sfx.value = _data.SFXVol;
        }

		public void SliderSFX()
		{
			SoundManager.SliderSFX(_sfx.value);
		}

		public void SliderMusic()
		{
			SoundManager.SliderMusic(_music.value);
		}

        public void Exit()
        {
			SaveManager.SaveAudio(_sfx.value, _music.value);
        }
    }
}
