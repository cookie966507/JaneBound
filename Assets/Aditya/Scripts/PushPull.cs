using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class PushPull : MonoBehaviour {

	public float animSpeed = 1.5f;				// a public setting for overall animator animation speed

	
	private Animator anim;							// a reference to the animator on the character
	private CapsuleCollider col;					// a reference to the capsule collider of the character
	Rigidbody body2;
	
	static int pushState = Animator.StringToHash("Base Layer.Push");
	
	Rigidbody self;
	float h, v;
	int flag = 0;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();					  
		col = GetComponent<CapsuleCollider>();				
		self = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		v = Input.GetAxis("Vertical");				// setup v variables as our vertical input axis
		anim.SetFloat("Speed", v);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.SetFloat("Direction", h); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis		
		anim.speed = animSpeed;	
		anim.SetBool("Push",false);
		anim.SetBool("Pull",false);

		if(flag == 1 && Input.GetKey(KeyCode.LeftShift))
		{
			if(v==1)
			{

				anim.SetBool("Push",true);

				self.velocity = self.velocity*1.5f; 
				body2.velocity = self.velocity;
			}
			else if (v==-1)
			{
				anim.SetBool("Pull",true);
				self.velocity = self.velocity*2f;
				body2.velocity = self.velocity*1.5f;
			}

		}
		else
			flag = 0;
	
	}
	void OnCollisionStay(Collision collision) 
	{
		if(collision.collider.attachedRigidbody != null && Input.GetKey(KeyCode.LeftShift) && collision.collider.attachedRigidbody.tag == "grabbable")
		{
			body2 = collision.collider.attachedRigidbody;
			flag = 1;

		}

	}


		
		
		
		
		
		

}
