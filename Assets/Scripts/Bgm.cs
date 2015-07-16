using UnityEngine;
using System.Collections;
using Assets.Scripts.Data;

public class Bgm : MonoBehaviour {

	// Use this for initialization

	AudioSource bgmSource;
	void Awake () {
		bgmSource = gameObject.GetComponent<AudioSource>();
	}
	void Start () {
		SoundManager.PlayMusic(bgmSource);
	}
}
