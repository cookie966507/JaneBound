using UnityEngine;
using Assets.Scripts.Data;
using System.Collections;

//add this class to hazards such as lava or spikes, use "effectedTags" to choose which objects can be hurt by this hazard
[RequireComponent(typeof(AudioSource))]
public class Bounce : MonoBehaviour 
{
	public float pushForce = 20f;							//how far away from this object to push the bounceObject when they hit this hazard
	public float pushHeight = 2f;							//how high to push bounceObject when they are hit by this hazard
	public bool triggerEnter;								//are we checking for a trigger collision? (ie: hits a child trigger symbolising area of effect)
	public bool collisionEnter = true;						//are we checking for collider collision? (ie: hits the actual collider of the object)
	public string[] effectedTags = {"Player"};				//which objects are vulnerable to this hazard (tags)
	public AudioClip hitSound;	
	public AudioClip bubblePop;	

	public ParticleSystem bubbleBurstSystem;

	private AudioSource asBubbleBounce;
	private AudioSource asBubblePop;
	//setup
	void Awake()
	{
		GetComponent<AudioSource>().playOnAwake = false;
		asBubbleBounce = gameObject.AddComponent<AudioSource>();
		asBubbleBounce.clip = hitSound;
		asBubblePop = gameObject.AddComponent<AudioSource>();
		asBubblePop.clip = bubblePop;
	}
	

	//if were checking for a physical collision, attack what hits this object
	void  OnCollisionEnter(Collision col)
	{
		if(!collisionEnter)
			return;
		foreach(string tag in effectedTags)
		{
			if(col.transform.tag == tag)
			{
				MakeBounce (col.gameObject, pushHeight, pushForce);
				if (hitSound)
				{
					asBubbleBounce.Play();
				}
			}
		}
		if(col.transform.tag.Equals("Janitor") || col.gameObject.layer == 13 || col.gameObject.tag == "Bubble")
		{
			bubbleBurstSystem.Play();

			if(asBubblePop!=null)
				asBubblePop.Play();

			GetComponent<MeshRenderer>().enabled = false;
			GetComponent<SphereCollider>().enabled = false;
			StartCoroutine(WaitToDestroy(1.0f));


		}
	}

	//destroys the bubble after waiting
	IEnumerator WaitToDestroy(float waitTime){
		if (waitTime > 0)
			yield return new WaitForSeconds(waitTime);
		Destroy(this.gameObject);
	}
	
	//if were checking for a trigger enter, attack what enters the trigger
	void OnTriggerEnter(Collider other)
	{
		if(!triggerEnter)
			return;
		foreach(string tag in effectedTags)
			if(other.transform.tag == tag)
				MakeBounce (other.gameObject, pushHeight, pushForce);
	}

	public void MakeBounce(GameObject bounceObject, float pushHeight, float pushForce)
	{
		//push
		Vector3 pushDir = (bounceObject.transform.position - transform.position);
		pushDir.y = 0f;
		pushDir.y = pushHeight * 0.1f;
		if (bounceObject.GetComponent<Rigidbody>() && !bounceObject.GetComponent<Rigidbody>().isKinematic)
		{
			Vector3 velocity = bounceObject.GetComponent<Rigidbody>().velocity;
			bounceObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			bounceObject.GetComponent<Rigidbody>().AddForce ((Vector3.up  * pushForce) + (velocity * pushForce / 8), ForceMode.Impulse);
			bounceObject.GetComponent<Rigidbody>().AddForce (Vector3.up * pushHeight, ForceMode.VelocityChange);
		}
	}
}

/* NOTE: a nice feature of unity is that the trigger enter check works with a child object trigger
 * so you might have a physical collider on the actual object, then a child trigger for the damage area
 * for example: a lawnmower which the player can stand on, and a blade on the front which damages objects */