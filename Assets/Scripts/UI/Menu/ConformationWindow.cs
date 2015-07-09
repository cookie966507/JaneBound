using UnityEngine;
using System.Collections;

namespace Assets.Scripts.UI.Menu
{
    class ConformationWindow : MenuElement
    {
        public delegate void Confirm(bool _confirm);
        private static Confirm confirmFunction;
        private static Canvas _win;

		protected override void Init ()
		{
			base.Init ();
			_state = MenuManager.MenuState.Confirmation;
		}

		public static void getConformation(Confirm confirmFunction)
        {
			ConformationWindow.confirmFunction = confirmFunction;
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
            _win.enabled = false;
        }
    }
}
