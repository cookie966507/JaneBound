using UnityEngine;
using System.Collections;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
	public class Settings : MenuElement
	{
		protected override void Init ()
		{
			base.Init ();
			_state = MenuManager.MenuState.Settings;
		}

		public void Audio()
		{
			MenuManager.StateTransition(_state, MenuManager.MenuState.Audio);
		}
		public void Video()
		{
			MenuManager.StateTransition(_state, MenuManager.MenuState.Video);
		}
		public void Back()
		{
			this.Deactivate();
			MenuManager.StateTransition(_state, MenuManager.MenuState.Title);
		}
	}
}
#endregion
