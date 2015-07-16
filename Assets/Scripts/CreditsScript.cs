using UnityEngine;
using System.Collections;
using Assets.Scripts.Data;


public class CreditsScript : MonoBehaviour {

	// Use this for initialization
	AudioSource bgmSource;
	void Awake () {
		bgmSource = gameObject.GetComponent<AudioSource>();
	}
	void Start () {
		GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetBool("playerDance",true);
		GameObject.FindGameObjectWithTag("CabbageGuy").GetComponent<Animator>().SetBool("dance",true);
		GameObject.FindGameObjectWithTag("Janitor").GetComponent<Animator>().SetBool("dance",true);
		GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>().SetBool("dance2",true);

		bgmSource.Play();
		//SoundManager.PlayMusic(bgmSource);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
