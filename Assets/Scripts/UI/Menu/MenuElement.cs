using UnityEngine;
using System.Collections;

#region ERIC
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
			this.Deactivate();
			DontDestroyOnLoad(this.gameObject);
		}

		public virtual void Activate()
		{
			_win.enabled = true;
		}

		public virtual void Deactivate()
		{
			_win.enabled = false;
		}
	}
}
#endregion
