using UnityEngine;
using System.Collections;

	namespace Assets.Scripts.UI.Menu
	{
	public abstract class MenuElement : MonoBehaviour {
		protected Canvas _win;
		protected MenuManager.MenuState _state;

		void Awake()
		{
			Init();
		}

		protected virtual void Init()
		{
			_win = this.GetComponent<Canvas>();
			_win.enabled = false;
		}

		public virtual void Activate()
		{
			_win.enabled = true;
		}
	}
}
