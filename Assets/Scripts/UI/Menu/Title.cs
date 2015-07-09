using UnityEngine;
using System.Collections;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
	public class Title : MenuElement
	{
		protected override void Init ()
		{
			_win = this.GetComponent<Canvas>();
			_state = MenuManager.MenuState.Title;
		}

		public void Play()
		{
			MenuManager.StateTransition(_state, MenuManager.MenuState.Inactive);
		}
		public void Settings()
		{
			MenuManager.StateTransition(_state, MenuManager.MenuState.Settings);
		}
		public void Credits()
		{

		}
	}
}
#endregion
