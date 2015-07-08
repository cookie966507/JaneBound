using UnityEngine;
using System.Collections;

namespace Assets.Scripts.UI
{
    class ConformationWindow : MonoBehaviour
    {
        public delegate void Confirm(bool _confirm);
        private static Confirm confirmFunction;
        private static Canvas _win;

		public static void getConformation(Confirm confirmFunction)
        {
			ConformationWindow.confirmFunction = confirmFunction;
            _win.enabled = true;
        }

        void Start()
        {
            _win = this.gameObject.GetComponent<Canvas>();
            _win.enabled = false;
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
