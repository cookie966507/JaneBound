using UnityEngine;
using System.Collections;

public class CopSound : MonoBehaviour {

	public AudioClip[] copClips;
	AudioSource copSource;
	Animator anim;
	static int i = 0;
	// Use this for initialization
	void Start () {
		copSource = gameObject.AddComponent<AudioSource>();
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(anim.GetBool("run"))
		{
			copSource.clip = copClips[i];
			if(!copSource.isPlaying)
			{
				copSource.PlayDelayed(2);
			}
			else
			{
				i = (i+1)%(copClips.Length);
				Debug.Log (i);
			}
		}
	}
}
