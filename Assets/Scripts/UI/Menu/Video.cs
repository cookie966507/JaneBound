using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts.Data;

namespace Assets.Scripts.UI.Menu
{
    class Video : MonoBehaviour
    {
        private Slider _resolution;
		private Text _resolutionText;
		private Slider _quality;
		private Text _qualityText;
		private Toggle _fullscreen;

		private static List<Resolution> _res;

        void Start()
        {
			_resolution = this.transform.Find("Resolution").GetComponent<Slider>();
			_quality = this.transform.Find("Quality").GetComponent<Slider>();
			_fullscreen = this.transform.Find("Fullscreen").GetComponent<Toggle>();
			_resolutionText = this.transform.Find("Resolution Text").GetComponent<Text>();
			_qualityText = this.transform.Find("Quality Text").GetComponent<Text>();

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
            _quality.minValue = 0f;
            _quality.maxValue = QualitySettings.names.Length - 1;
           
			VideoData _data = LoadManager.LoadVideo();
			_resolution.value = _data.ResolutionIndex;
			_quality.value = _data.QualityIndex;
			_fullscreen.isOn = _data.Fullscreen;
            _resolutionText.text = _res[(int)_resolution.value].width + "x" + _res[(int)_resolution.value].height;
            _qualityText.text = QualitySettings.names[(int)_quality.value];
        }

        public void ResolutionOption()
        {
			_resolution.value = (int)_resolution.value;
			_resolutionText.text = _res[(int)_resolution.value].width + "x" + _res[(int)_resolution.value].height;
        }

		public void QualityOption()
		{
			_quality.value = (int)_quality.value;
			_qualityText.text = QualitySettings.names[(int)_quality.value];
		}

        public void FullscreenOption()
        {
           _fullscreen.isOn = !_fullscreen.isOn;
        }

        public void Exit()
        {
			Screen.SetResolution(
				_res[(int)_resolution.value].width,
				_res[(int)_resolution.value].height,
				_fullscreen.isOn);

			FindObjectOfType<Camera>().ResetAspect();

			QualitySettings.SetQualityLevel((int)_quality.value);
			SaveManager.SaveVideo((int)_resolution.value, (int)_quality.value, _fullscreen.isOn);
        }
    }
}
