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
			if(i == 1)
			{
				MenuManager.StateTransition(MenuManager.MenuState.Title, MenuManager.MenuState.Title);
				_play.Select();
			}
		}

		public void Play()
		{
			if(Data.GameManager.IsLoading) return;
			MenuManager.StateTransition(_state, MenuManager.MenuState.Inactive);
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			Data.GameManager.Load("FINALNPCLevel(for now...!)");
		}

		public void Settings()
		{
			if(Data.GameManager.IsLoading) return;
			this.Deactivate();
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Settings);
		}

		public void Credits()
		{
			if(Data.GameManager.IsLoading) return;
			MenuManager.StateTransition(_state, MenuManager.MenuState.Credits);
			this.Deactivate();
			Data.GameManager.Load("Credits");
		}
	}
}
#endregion
