using UnityEngine;
using UnityEngine.UI;
using System.Collections;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
	public class Title : MenuElement
	{
		private Button _play;
		private static Title _instance;

		protected override void Init ()
		{
			GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetBool("playerDance",true);
			if(_instance == null)
			{
				_instance = this;
			}
			else if(_instance != this)
			{
				Destroy(this.gameObject);
			}
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
