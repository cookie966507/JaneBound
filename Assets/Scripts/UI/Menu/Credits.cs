using UnityEngine;
using System.Collections;

namespace Assets.Scripts.UI.Menu
{
	public class Credits : MenuElement
	{
		public void Back()
		{
			Application.LoadLevel("Title");
			MenuManager.StateTransition(MenuManager.MenuState.Title, MenuManager.MenuState.Title);
			this.Deactivate();
		}
	}
}
