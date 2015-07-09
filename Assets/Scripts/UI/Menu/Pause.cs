using UnityEngine;
using System.Collections;
using Assets.Scripts.Data;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
	public class Pause : MenuElement
	{
		void OnEnable()
		{
			GameManager.GameUnpause += Resume;
		}
		void OnDisable()
		{
			GameManager.GameUnpause -= Resume;
		}

		protected override void Init ()
		{
			base.Init ();
			_state = MenuManager.MenuState.Pause;
		}

		public void Resume()
		{
			this.Deactivate();
		}

		public void Settings()
		{
			MenuManager.StateTransition(_state, MenuManager.MenuState.Settings);
		}

		public void Restart()
		{
			ConfirmationWindow.GetConfirmation(RestartLevel, ConfirmationWindow.ConfirmationType.AreYouSure);
		}
		private void RestartLevel(bool _accept)
		{
			if(_accept) Application.LoadLevel(Application.loadedLevel);
		}

		public void Quit()
		{
			ConfirmationWindow.GetConfirmation(QuitLevel, ConfirmationWindow.ConfirmationType.AreYouSure);
		}
		private void QuitLevel(bool _accept)
		{
			if(_accept) Application.LoadLevel("Title");
			MenuManager.StateTransition(MenuManager.MenuState.Title, MenuManager.MenuState.Title);
		}
	}
}
#endregion
