using UnityEngine;
using System.Collections;

namespace Assets.Scripts.UI.Menu
{
    class ConformationWindow : MonoBehaviour
    {
        public delegate void Confirm(bool _confirm);
        private static Confirm confirmFunction;
		private static Canvas _win;

		void Awake()
		{
			_win = this.GetComponent<Canvas>();
			_win.enabled = false;
		}

		public static void getConformation(Confirm confirmFunction)
        {
			ConformationWindow.confirmFunction = confirmFunction;
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.MenuState.Confirmation);
            _win.enabled = true;
        }

        public void Yes()
        {
            doAnswer(true);
        }
        public void No()
        {
            doAnswer(false);
        }
        private static void doAnswer(bool yesNo)
        {
			confirmFunction(yesNo);
			MenuManager.StateTransition(MenuManager.MenuState.NoStateOverride, MenuManager.PreviousState);
            _win.enabled = false;
        }
    }
}
