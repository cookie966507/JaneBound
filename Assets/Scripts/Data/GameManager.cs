using UnityEngine;
using System.Collections;
using Assets.Scripts.Util;

#region ERIC
namespace Assets.Scripts.Data
{
	public class GameManager : MonoBehaviour
	{
		public enum GameState
		{
			Loading,
			Running,
			Paused,
			Win,
			Lose,
			Dead
		}

		private static GameManager _instance;

		private static GameState _state;

		public delegate void PauseAction();
		public static event PauseAction GamePause;
		public static event PauseAction GameUnpause;
		private static bool _shouldPause;

		void OnEnable()
		{
			Player.PlayerLife.PlayerDie += Lose;
			WinTrigger.PlayerWin += Win;
		}
		void OnDisable()
		{
			Player.PlayerLife.PlayerDie -= Lose;
			WinTrigger.PlayerWin -= Win;
		}

		void Awake()
		{
			if(_instance == null)
			{
				DontDestroyOnLoad(this.gameObject);
				_instance = this;
			}
			else if(_instance != this)
			{
				Debug.Log("Too many game managers");
				Destroy(this.gameObject);
			}

			_state = GameState.Running;
		}

		void Update()
		{
			if(_shouldPause && !IsPaused)
			{
				_state = GameState.Paused;
				if(GamePause != null) GamePause();
			}
			if(!_shouldPause && IsPaused)
			{
				_state = GameState.Running;
				if(GameUnpause != null) GameUnpause();
			}
		}

		public static void ResetLevel()
		{
			_shouldPause = false;
			if(GameUnpause != null) GameUnpause();
			Application.LoadLevel(Application.loadedLevel);
		}

		public void Win()
		{
			UI.Menu.MenuManager.StateTransition(Assets.Scripts.UI.Menu.MenuManager.MenuState.NoStateOverride, Assets.Scripts.UI.Menu.MenuManager.MenuState.Win);
			_state = GameState.Win;
			if(GamePause != null) GamePause();
		}
		public void Lose()
		{
			UI.Menu.MenuManager.StateTransition(Assets.Scripts.UI.Menu.MenuManager.MenuState.NoStateOverride, Assets.Scripts.UI.Menu.MenuManager.MenuState.Lose);
			_state = GameState.Lose;
			if(GamePause != null) GamePause();
		}

		public static bool IsPaused
		{
			get { return _state.Equals(GameState.Paused); }
		}
		public static bool InSuspendedState
		{
			get { return _state.Equals(GameState.Paused) || _state.Equals(GameState.Win) || _state.Equals(GameState.Lose); }
		}
		public static bool ShouldPause
		{
			get { return _shouldPause; }
			set { _shouldPause = value; }
		}
	}
}
#endregion