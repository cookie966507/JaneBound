using UnityEngine;
using UnityEngine.UI;
using System.Collections;

#region ERIC
namespace Assets.Scripts.UI
{
	public class LoadingScreen : MonoBehaviour
	{
		public static LoadingScreen _instance;
		private static string _levelToLoad = "Title";

		private Image _bubble;
		private Vector3 _scale = new Vector3(0, 0, 0);
		private float _currentSize = 0f;
		private float _scaleStep = 0.1f;
		private float _maxScale = 3f;

		private Canvas _win;

		private float _vel;
		private float _smoothTime = 0.1f;

		void Awake()
		{
			if(_instance == null)
			{
				_instance = this;
				DontDestroyOnLoad(this.gameObject);
			}
			else if(_instance != this)
			{
				Destroy(this.gameObject);
			}

			_win = this.GetComponent<Canvas>();
			_bubble = transform.FindChild("LoadingBubble").GetComponent<Image>();

			Data.GameManager.Load(_levelToLoad);
		}

		private void Init()
		{
			_scale = new Vector3(0, 0, 0);
			_bubble.transform.localScale = _scale;
			_currentSize = 0f;
		}

		public void LoadNextLevel()
		{
			StartCoroutine(Load(_levelToLoad));
		}

		private IEnumerator Load(string _level)
		{
			this.Init ();
			_win.enabled = true;
			AsyncOperation _async = Application.LoadLevelAsync(_level);
			while(!_async.isDone)
			{
				_currentSize = Mathf.SmoothDamp(_currentSize, _currentSize + _scaleStep, ref _vel, _smoothTime);
				if(_currentSize > _maxScale) _currentSize = 0f;
				_scale = new Vector3(_currentSize, _currentSize, 0f);
				_bubble.transform.localScale = _scale;

				yield return null;
			}
			_win.enabled = false;
			Data.GameManager.FinishedLoading();
		}

		public static string LevelToLoad
		{
			set { _levelToLoad = value; }
		}
	}
}
#endregion