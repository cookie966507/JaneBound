using UnityEngine;
using UnityEngine.UI;
using System.Collections;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
	public class Settings : MenuElement
	{
		private static Settings _instance;

		private Button _audio;

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
			_state = MenuManager.MenuState.Settings;
			_audio = GameObject.Find("Audio").GetComponent<Button>();
		}
		
		public override void Activate ()
		{
			base.Activate ();
			_audio.Select();
		}

		public void Audio()
		{
			this.Deactivate();
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Audio);
		}
		public void Video()
		{
			this.Deactivate();
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Video);
		}
		public void Back()
		{
			this.Deactivate();
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.PreviousState);
		}
	}
}
#endregion
