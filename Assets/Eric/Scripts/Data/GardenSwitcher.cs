using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Data
{
	public class GardenSwitcher : MonoBehaviour
	{
		public string[] _gardens;

		private static GardenSwitcher _instance;
		
		void Awake()
		{
			if(_instance == null)
			{
				DontDestroyOnLoad(this.gameObject);
				_instance = this;
			}
			else if(_instance != this)
			{
				Debug.Log("Too many garden switchers");
				Destroy(this.gameObject);
			}
		}

		void Update()
		{
			if(Input.GetKeyDown(KeyCode.Alpha1))
			{
				Application.LoadLevel(_gardens[0]);
			}
			if(Input.GetKeyDown(KeyCode.Alpha2))
			{
				Application.LoadLevel(_gardens[1]);
			}
			if(Input.GetKeyDown(KeyCode.Alpha3))
			{
				Application.LoadLevel(_gardens[2]);
			}
			if(Input.GetKeyDown(KeyCode.Alpha4))
			{
				Application.LoadLevel(_gardens[3]);
			}
			if(Input.GetKeyDown(KeyCode.Alpha5))
			{
				Application.LoadLevel(_gardens[4]);
			}
		}
	}
}
