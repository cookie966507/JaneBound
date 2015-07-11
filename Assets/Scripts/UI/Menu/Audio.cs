using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Data;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
    class Audio : MenuElement
    {
        private Slider _music;
        private Slider _sfx;

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

        public void Back()
        {
			SaveManager.SaveAudio(_sfx.value, _music.value);
			this.Deactivate();
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Settings);
        }
    }
}
#endregion
