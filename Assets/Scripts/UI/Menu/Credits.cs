﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.UI.Menu
{
	public class Credits : MenuElement
	{
		private Button _back;

		protected override void Init ()
		{
			base.Init ();
			_back = GameObject.Find("Credits_Back").GetComponent<Button>();
		}
		public override void Activate ()
		{
			base.Activate ();
			_back.Select();
		}
		public void Back()
		{
			Application.LoadLevel("Title");
			MenuManager.StateTransition(MenuManager.MenuState.Title, MenuManager.MenuState.Title);
			this.Deactivate();
		}
		void OnLevelWasLoaded(int i)
		{
			if(i == 1) _back.Select();
		}
	}
}
