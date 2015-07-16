using UnityEngine;
using System.Collections;

public class AlarmRing : MonoBehaviour {

	//public AudioClip alarmSound;
	AudioSource alarmSource;

	// Use this for initialization
	void Start () {
		alarmSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		Assets.Scripts.Data.SoundManager.PlaySFX(alarmSource);
	}
}