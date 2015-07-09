﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using Assets.Scripts.Data;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
	public class Pause : MenuElement
	{
		Button[] _buttons;

		protected override void Init ()
		{
			base.Init ();
			_buttons = transform.GetComponentsInChildren<Button>();
			_state = MenuManager.MenuState.Pause;
			this.ToggleButtons(true);
		}

		public override void Activate ()
		{
			base.Activate ();
			this.ToggleButtons(true);
		}

		public void Resume()
		{
			GameManager.ShouldPause = false;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Inactive);
			this.ToggleButtons(false);
		}

		public void Settings()
		{
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Settings);
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
				MenuManager.StateTransition(MenuManager.MenuState.Pause, MenuManager.MenuState.Pause);
			}
		}

		public void Quit()
		{
			ConfirmationWindow.GetConfirmation(QuitLevel, ConfirmationWindow.ConfirmationType.AreYouSure);
		}
		private void QuitLevel(bool _accept)
		{
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
				_buttons[i].enabled = enabled;
			}
		}
	}
}
#endregion
