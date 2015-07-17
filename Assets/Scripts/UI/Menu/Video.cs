using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts.Data;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
    class Video : MenuElement
    {
		private static Video _instance;
        private Slider _resolution;
		private Text _resolutionText;
		private Slider _quality;
		private Text _qualityText;
		private Toggle _fullscreen;

		private bool _update;
		private bool _back;

		private static List<Resolution> _res;

		protected override void Init ()
		{
			if(_instance == null)
			{
				_instance = this;
			}
			else if(_instance != this)
			{
				Destroy(this.gameObject);
			}
			base.Init ();
			_state = MenuManager.MenuState.Video;
		}
        void Start()
        {
			_resolution = GameObject.Find("Resolution").GetComponent<Slider>();
			_quality = GameObject.Find("Quality").GetComponent<Slider>();
			_fullscreen = GameObject.Find("Fullscreen").GetComponent<Toggle>();
			_resolutionText = GameObject.Find("Resolution Text").GetComponent<Text>();
			_qualityText = GameObject.Find("Quality Text").GetComponent<Text>();

			_res = new List<Resolution>();
			double num = 0;
            foreach (Resolution r in Screen.resolutions)
            {
                num = r.width / 16.0;
                if ((double)(r.height) / num - 9 < 1 && (double)(r.height) / num - 9 > -1)
                {
                    _res.Add(r);
                }
            }
            if (_res.Count == 0)
                _res.Add(Screen.resolutions[0]);

			_resolution.minValue = 0f;
            _resolution.maxValue = _res.Count - 1;
           
			VideoData _data = LoadManager.LoadVideo();
			_resolution.value = _data.ResolutionIndex;
			_fullscreen.isOn = false;
            _resolutionText.text = _res[(int)_resolution.value].width + "x" + _res[(int)_resolution.value].height;

#if !UNITY_WEBPLAYER
			_quality.minValue = 0f;
			_quality.maxValue = QualitySettings.names.Length - 1;

			_quality.value = _data.QualityIndex;
            _qualityText.text = QualitySettings.names[(int)_quality.value];
#else
			_quality.interactable = false;
			
			Navigation _newNav = new Navigation();
			_newNav.mode = Navigation.Mode.Explicit;
			_newNav.selectOnUp = _resolution.navigation.selectOnUp;
			_newNav.selectOnDown = _fullscreen;
			_resolution.navigation = _newNav;
			
			_newNav.selectOnUp = _resolution;
			_newNav.selectOnDown = _fullscreen.navigation.selectOnDown;
			_fullscreen.navigation = _newNav;
#endif
			ApplySettings(true);
        }

		public override void Activate ()
		{
			base.Activate ();

			VideoData _data = LoadManager.LoadVideo();
			_resolution.value = _data.ResolutionIndex;
			_resolutionText.text = _res[(int)_resolution.value].width + "x" + _res[(int)_resolution.value].height;
			
			_quality.value = _data.QualityIndex;
			_qualityText.text = QualitySettings.names[(int)_quality.value];
			
			_fullscreen.isOn = _data.Fullscreen;

			_update = false;

			_resolution.Select();
		}

        public void ResolutionOption()
        {
			_resolution.value = (int)_resolution.value;
			_resolutionText.text = _res[(int)_resolution.value].width + "x" + _res[(int)_resolution.value].height;
			_update = true;
        }

		public void QualityOption()
		{
			_quality.value = (int)_quality.value;
			_qualityText.text = QualitySettings.names[(int)_quality.value];
			_update = true;
		}

        public void FullscreenOption()
        {
			_update = true;
        }

		public void Apply()
		{
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Confirmation);
			ConfirmationWindow.GetConfirmation(ApplySettings, ConfirmationWindow.ConfirmationType.ApplyChanges, _state);
		}

		public void ApplySettings(bool _accept)
		{
			if(MenuManager.CurrentState != MenuManager.MenuState.Title)	_resolution.Select();
			if(!_accept)
			{
				if(_back) this.GoBack();
				return;
			}
			Screen.SetResolution(
				_res[(int)_resolution.value].width,
				_res[(int)_resolution.value].height,
				_fullscreen.isOn);
			
			FindObjectOfType<Camera>().ResetAspect();
			
			QualitySettings.SetQualityLevel((int)_quality.value);
			SaveManager.SaveVideo((int)_resolution.value, (int)_quality.value, _fullscreen.isOn);
			_update = false;
			if(_back) this.GoBack();
		}

        public void Back()
        {
			_back = true;
			if(_update)
			{
				MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Confirmation);
				ConfirmationWindow.GetConfirmation(ApplySettings, ConfirmationWindow.ConfirmationType.ApplyChanges, MenuManager.MenuState.Settings);
			}
			else this.GoBack();
        }

		public void GoBack()
		{
			_back = false;
			this.Deactivate();
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Settings);
		}
    }
}
#endregion
