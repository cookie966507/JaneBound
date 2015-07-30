using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.UI.Menu
{
	public class Win : MenuElement
	{
		private static Win _instance;
		private Button _continue;

		void OnLevelWasLoaded(int i)
		{
			this.Deactivate();
		}
		
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
			_continue = GameObject.Find("Win_Continue").GetComponent<Button>();
			_state = MenuManager.MenuState.Win;
		}
		public override void Activate ()
		{
			base.Activate ();
			_continue.Select();
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		public void Continue()
		{
			Data.GameManager.Load("Credits");
			MenuManager.StateTransition(MenuManager.MenuState.Title, MenuManager.MenuState.Credits);
			this.Deactivate();
		}
	}
}
