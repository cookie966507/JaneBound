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
			GameManager.ShouldPause = false;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			this.ToggleButtons(false);
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Inactive);
		}

		public void Settings()
		{
			MenuManager.StateTransition(MenuManager.MenuState.Pause, MenuManager.MenuState.Settings);
		}

		public void Restart()
		{
			ConfirmationWindow.GetConfirmation(RestartLevel, ConfirmationWindow.ConfirmationType.AreYouSure);
		}
		private void RestartLevel(bool _accept)
		{
			if(_accept)
			{
				this.Resume();

				Application.LoadLevel(Application.loadedLevel);
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
			ConfirmationWindow.GetConfirmation(QuitLevel, ConfirmationWindow.ConfirmationType.AreYouSure);
		}
		private void QuitLevel(bool _accept)
		{
			_buttons[0].Select();
			if(_accept)
			{
				this.Resume();
				Application.LoadLevel("Title");
				MenuManager.StateTransition(MenuManager.MenuState.Title, MenuManager.MenuState.Title);
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
