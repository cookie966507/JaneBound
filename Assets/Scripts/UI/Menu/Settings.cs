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
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Audio);
		}
		public void Video()
		{
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
