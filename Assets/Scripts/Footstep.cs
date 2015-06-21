using UnityEngine;
using System.Collections;
using Assets.Scripts.Player;
//by: Shawn Kim
public class Footstep : MonoBehaviour {

	PlayerMove cc;
	AudioSource audio;

	void Start () {
		cc = GetComponent<PlayerMove> ();
		audio = GetComponent<AudioSource>();
	}

	void Update () {
		//Temp for grass sound only
		if(cc.grounded == true && cc.isMoving && GetComponent<AudioSource>().isPlaying == false){
			audio.clip = cc.grassSound;
			audio.volume = Random.Range (0.8f, 1);
			audio.pitch = 2f;
			audio.Play();
		}
	}
}
