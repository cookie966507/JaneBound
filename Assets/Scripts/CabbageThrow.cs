using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
	public class CabbageThrow : MonoBehaviour {
		public float cabbage_force = 1000;
		public float armHeight = 5;
		public Vector3 predictVector;
		public AudioClip[] cabbageClips;
		AudioSource cabbageSource;
		static int i = 0;

		void Start () {

			predictVector = Vector3.zero;
			cabbageSource = gameObject.AddComponent<AudioSource>();


		}

		void ThrowCabbage()
		{
			Vector3 throwPosition = transform.position;
			throwPosition.Set(transform.position.x,transform.position.y+armHeight,transform.position.z);
			//Debug.Log (throwPosition);
			GameObject cabbage = (GameObject)GameObject.Instantiate(Resources.Load("Food_Watermelon"),throwPosition,Quaternion.identity);
			Rigidbody cabbage_body = cabbage.GetComponent<Rigidbody>();
			cabbage_body.AddForce(predictVector*cabbage_force);
			//AudioSource clip = (AudioSource)AudioSource.Instantiate(Resources.Load("CabbageGuyAngry"));


			cabbageSource.clip = cabbageClips[i];


			if(!cabbageSource.isPlaying)
			{
				//Data.SoundManager.PlaySFX(cabbageSource);
				cabbageSource.Play();
			}
			else
			{
				i = (i+1)%(cabbageClips.Length);
				Debug.Log (i);
			}

			
			//cabbageSource.Play();
		//	clip.Play();


		}
	}
}