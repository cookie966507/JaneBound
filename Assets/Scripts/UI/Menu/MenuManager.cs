using UnityEngine;
using System;
using System.Collections;
using Assets.Scripts.Data;

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
				StateTransition(_previousState, _currentState);
			}
			else if(_instance != this) Destroy(this.gameObject);
		}

		void Update()
		{
			if(!GameManager.InSuspendedState)
			{
				if(Input.GetKeyDown(KeyCode.Return))
				{
					Debug.Log(_currentState);
					if(_currentState.Equals(MenuState.Inactive))
					{
						StateTransition(_currentState, MenuState.Pause);
						GameManager.ShouldPause = true;
					}
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
			case MenuState.Inactive:
				DeactivateAll();
				break;
			}
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

		public static MenuState PreviousState
		{
			get { return _previousState; }
		}
	}
}
#endregion
