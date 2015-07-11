using UnityEngine;
using System.Collections;
using Assets.Scripts.Data;

public class CopSound : MonoBehaviour {

	public AudioClip[] copClips;
	AudioSource copSource;
	Animator anim;
	static int i = 0;

	private float _timer = 0f;
	private float _soundDelay = 2f;

	// Use this for initialization
	void Start () {
		copSource = gameObject.GetComponent<AudioSource>();
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameManager.InSuspendedState)
		{
			if(anim.GetBool("run"))
			{
				_timer += Time.deltaTime;
				if(_timer > _soundDelay)
				{
					_timer = 0f;
					copSource.clip = copClips[i];
					if(!copSource.isPlaying)
					{
						//copSource.PlayDelayed(2);
						Assets.Scripts.Data.SoundManager.PlaySFX(copSource);
					}
					else
					{
						i = (i+1)%(copClips.Length);
						Debug.Log (i);
					}
				}
			}
		}
	}
}
