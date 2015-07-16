using UnityEngine;
using System.Collections;

public class Bgm : MonoBehaviour {

	// Use this for initialization

	AudioSource bgmSource;
	void Awake () {
		bgmSource = gameObject.GetComponent<AudioSource>();
	}
	void Start () {
		bgmSource.Play();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
