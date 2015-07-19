using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using Assets.Scripts.Data;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
	public class Pause : MenuElement
	{
		private static Pause _instance;
		private Button[] _buttons;

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
			_buttons = transform.GetComponentsInChildren<Button>();
			_state = MenuManager.MenuState.Pause;
			this.ToggleButtons(false);
		}

		public override void Activate ()
		{
			base.Activate ();
			this.ToggleButtons(true);
			_buttons[0].Select();
		}

		public void Resume()
		{
			if(Data.GameManager.IsLoading) return;
			GameManager.ShouldPause = false;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			this.ToggleButtons(false);
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Inactive);
		}

		public void Settings()
		{
			if(Data.GameManager.IsLoading) return;
			MenuManager.StateTransition(MenuManager.MenuState.Pause, MenuManager.MenuState.Settings);
		}

		public void Restart()
		{
			if(Data.GameManager.IsLoading) return;
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Confirmation);
			ConfirmationWindow.GetConfirmation(RestartLevel, ConfirmationWindow.ConfirmationType.AreYouSure, _state);
		}
		private void RestartLevel(bool _accept)
		{
			if(_accept)
			{
				this.Resume();

				Data.GameManager.Load(Application.loadedLevelName);
				MenuManager.StateTransition(MenuManager.MenuState.Inactive, MenuManager.MenuState.Inactive);
				this.Deactivate();
			}
			else
			{
				_buttons[0].Select();
				MenuManager.StateTransition(MenuManager.MenuState.Pause, MenuManager.MenuState.Pause);
			}
		}

		public void Quit()
		{
			if(Data.GameManager.IsLoading) return;
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Confirmation);
			ConfirmationWindow.GetConfirmation(QuitLevel, ConfirmationWindow.ConfirmationType.AreYouSure, _state);
		}
		private void QuitLevel(bool _accept)
		{
			_buttons[0].Select();
			if(_accept)
			{
				this.Resume();
				Data.GameManager.Load("Title");
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}

		private void ToggleButtons(bool _enabled)
		{
			for(int i = 0; i < _buttons.Length; i++)
			{
				_buttons[i].enabled = _enabled;
			}
		}
	}
}
#endregion
