using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Player
{
	public class CabbageKill : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void OnCollisionEnter(Collision collider)
		{
			if(collider.transform.tag == "Player" && transform.position.y>0.6f)
			{
				PlayerLife pl = collider.gameObject.GetComponent<PlayerLife>();
				pl.Health=0f;
			}
		}

	}
}
