using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.UI.Menu
{
	public class Lose : MenuElement
	{
		private static Lose _instance;
		private Button _restart;
		
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
			_restart = GameObject.Find("Lose_Restart").GetComponent<Button>();
			_state = MenuManager.MenuState.Lose;
		}
		public override void Activate ()
		{
			base.Activate ();
			_restart.Select();
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		public void Restart()
		{
			Data.GameManager.ShouldPause = false;
			Application.LoadLevel(Application.loadedLevel);
			MenuManager.StateTransition(MenuManager.MenuState.Inactive, MenuManager.MenuState.Inactive);
			this.Deactivate();
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		public void Quit()
		{
			Application.LoadLevel("Title");
			MenuManager.StateTransition(MenuManager.MenuState.Title, MenuManager.MenuState.Title);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			this.Deactivate();
		}
	}
}
