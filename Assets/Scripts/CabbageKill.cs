using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Player
{
	public class CabbageKill : MonoBehaviour {

		Rigidbody cabbageBody;
		void Start () {
			
			cabbageBody = gameObject.GetComponent<Rigidbody>();
			
		}
		void OnCollisionEnter(Collision collider)
		{
			Debug.Log (cabbageBody.velocity.magnitude);
			if(collider.transform.tag == "Player" &&(cabbageBody.transform.position.y - collider.transform.position.y)>0.7f)
			{
				PlayerLife pl = collider.gameObject.GetComponent<PlayerLife>();
				pl.Health=0f;
			}

		}

	}
}
