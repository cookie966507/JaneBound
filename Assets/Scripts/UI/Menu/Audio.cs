using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Data;

namespace Assets.Scripts.UI.Menu
{
    class Audio : MenuElement
    {
        public Slider _music;
        public Slider _sfx;

		protected override void Init ()
		{
			base.Init ();
			_state = MenuManager.MenuState.Audio;
		}
        void Start()
        {
			_music = GameObject.Find("Music").GetComponent<Slider>();
			_sfx = GameObject.Find("SFX").GetComponent<Slider>();

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
