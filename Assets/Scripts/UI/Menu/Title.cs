using UnityEngine;
using UnityEngine.UI;
using System.Collections;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
	public class Title : MenuElement
	{
		private Button _play;

		protected override void Init ()
		{
			base.Init();
			_state = MenuManager.MenuState.Title;
			_play = GameObject.Find("Play").GetComponent<Button>();
		}
		public override void Activate ()
		{
			base.Activate ();
			_play.Select();
		}

		void OnLevelWasLoaded(int i)
		{
			if(i == 0) _play.Select();
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
			this.Deactivate();
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
