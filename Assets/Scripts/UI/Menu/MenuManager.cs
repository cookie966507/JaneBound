using UnityEngine;
using System;
using System.Collections;
using Assets.Scripts.Data;
using UnityEngine.EventSystems;
using TeamUtility.IO;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
	public class MenuManager : MonoBehaviour {
		public enum MenuState
		{
			Title,
			Settings,
			Audio,
			Video,
			Pause,
			Confirmation,
			Inactive,
			Credits,
			Win,
			Lose,
			NoStateOverride
		}

		public static MenuManager _instance;
		private static MenuState _currentState;
		private static MenuState _previousState;

		private static MenuElement[] _menuElements;

		void Awake()
		{
			if(_instance == null)
			{
				_instance = this;
				DontDestroyOnLoad(this.gameObject);
				_currentState = MenuState.Title;
				_previousState = MenuState.Title;
				_menuElements = GameObject.FindObjectsOfType<MenuElement>();
			}
			else if(_instance != this) Destroy(this.gameObject);
		}

		void Start()
		{
			StateTransition(_previousState, _currentState);
		}

		void Update()
		{
			//Debug.Log(EventSystem.current.currentSelectedGameObject);
			if(!GameManager.InSuspendedState)
			{
				if(InputManager.GetButtonDown("Pause"))
				{
					if(_currentState.Equals(MenuState.Inactive))
					{
						StateTransition(_currentState, MenuState.Pause);
						GameManager.ShouldPause = true;
					}
					else if(_currentState.Equals(MenuState.Pause))
					{
						Pause _pause = (Pause)GetElement(typeof(Pause));
						_pause.Resume();
					}
				}
			}
			else if(GameManager.IsPaused)
			{
				if(InputManager.GetButtonDown("Pause"))
				{
					if(_currentState.Equals(MenuState.Pause))
					{
						Pause _pause = (Pause)GetElement(typeof(Pause));
						_pause.Resume();
					}
				}
			}
			if(InputManager.GetButtonDown("Cancel") && _currentState != MenuState.Confirmation)
			{
				switch(_currentState)
				{
				case MenuState.Audio:
					((Audio)GetElement(typeof(Audio))).Back();
					break;
				/*case MenuState.Confirmation:
					ConfirmationWindow _w = GameObject.Find("ConfirmationWindow").GetComponent<ConfirmationWindow>();
					_w.No();
					break;*/
				case MenuState.Credits:
					((Credits)GetElement(typeof(Credits))).Back();
					break;
				case MenuState.Pause:
					((Pause)GetElement(typeof(Pause))).Resume();
					break;
				case MenuState.Settings:
					((Settings)GetElement(typeof(Settings))).Back();
					break;
				case MenuState.Video:
					((Video)GetElement(typeof(Video))).Back();
					break;
				}
			}
		}

		public static void StateTransition(MenuState _currState, MenuState _nextState)
		{
			if(!_currState.Equals(MenuState.NoStateOverride)) _previousState = _currState;
			_currentState = _nextState;

			switch(_currentState)
			{
			case MenuState.Title:
				ActivateElement(typeof(Title));
				break;
			case MenuState.Settings:
				ActivateElement(typeof(Settings));
				break;
			case MenuState.Audio:
				ActivateElement(typeof(Audio));
				break;
			case MenuState.Video:
				ActivateElement(typeof(Video));
				break;
			case MenuState.Pause:
				ActivateElement(typeof(Pause));
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;
			case MenuState.Credits:
				ActivateElement(typeof(Credits));
				break;
			case MenuState.Win:
				ActivateElement(typeof(Win));
				break;
			case MenuState.Lose:
				ActivateElement(typeof(Lose));
				break;
			case MenuState.Inactive:
				DeactivateAll();
				break;
			}
		}

		/*void OnLevelWasLoaded(int i)
		{
			if(i == 1)
			{
				MenuManager.StateTransition(MenuManager.MenuState.Title, MenuManager.MenuState.Title);
				Debug.Log("Title");
			}
		}*/

		public static MenuElement GetElement(Type _type)
		{
			for(int i = 0; i < _menuElements.Length; i++)
			{
				if(_menuElements[i].GetType().Equals(_type))
				{
					return _menuElements[i];
				}
			}
			return null;
		}

		public static void ActivateElement(Type _type)
		{
			MenuElement _element;
			for(int i = 0; i < _menuElements.Length; i++)
			{
				if(_menuElements[i].GetType().Equals(_type))
				{
					_element = _menuElements[i];
					_element.Activate();
					break;
				}
			}
		}

		public static void DeactivateAll()
		{
			for(int i = 0; i < _menuElements.Length; i++)
			{
				_menuElements[i].Deactivate();
			}
		}

		public static MenuState CurrentState
		{
			get { return _currentState; }
		}
		public static MenuState PreviousState
		{
			get { return _previousState; }
		}
	}
}
#endregion
