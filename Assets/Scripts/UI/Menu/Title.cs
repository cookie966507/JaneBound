using UnityEngine;
using System.Collections;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
	public class Title : MenuElement
	{
		protected override void Init ()
		{
			base.Init();
			_state = MenuManager.MenuState.Title;
		}

		public void Play()
		{
			MenuManager.StateTransition(_state, MenuManager.MenuState.Inactive);
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			Application.LoadLevel("FINALNPCLevel(for now...!)");
		}

		public void Settings()
		{
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Settings);
		}

		public void Credits()
		{
			MenuManager.StateTransition(_state, MenuManager.MenuState.Credits);
			this.Deactivate();
			Application.LoadLevel("Credits");
		}
	}
}
#endregion
