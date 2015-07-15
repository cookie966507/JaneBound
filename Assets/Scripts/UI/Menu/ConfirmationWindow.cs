using UnityEngine;
using System.Collections;
using UnityEngine.UI;

#region ERIC
namespace Assets.Scripts.UI.Menu
{
    class ConfirmationWindow : MonoBehaviour
    {
		public enum ConfirmationType { ApplyChanges, AreYouSure }
        public delegate void Confirm(bool _confirm);
        private static Confirm confirmFunction;
		private static Canvas _win;
		private static Text _label;
		private static ConfirmationType _type;
		private static Button _yes;

		void Awake()
		{
			_win = this.GetComponent<Canvas>();
			_label = this.GetComponentInChildren<Text>();
			_win.enabled = false;

			_yes = GameObject.Find("Yes").GetComponent<Button>();
		}

		public static void GetConfirmation(Confirm confirmFunction, ConfirmationType _type)
        {
			ConfirmationWindow.confirmFunction = confirmFunction;

			if(_type.Equals(ConfirmationType.ApplyChanges))	_label.text = "Apply Changes?";
			else _label.text = "Are you sure?";

            _win.enabled = true;
			_yes.Select();
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
#endregion
