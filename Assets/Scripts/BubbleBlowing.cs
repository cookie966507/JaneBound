using UnityEngine;
using System.Collections;
using Assets.Scripts.Player;
using Assets.Scripts.Data;
using TeamUtility.IO;

public class BubbleBlowing : MonoBehaviour {
	

	public float start_bubble_distance = 1.0f;
	public float current_bubble_distance = 1.0f;
	public float bubble_height = 1.7f;

	public float max_scale = 3f; //how big can the bubble get
	public float growth_rate = 1.0f; //how fast does the bubble grow
	public float current_scale = 0.1f; //how big is the bubble right now
	public float start_scale = 0.1f; // how big does the bubble start out
	public Texture2D bubble_texture;
	public float bubble_force = 1000;
	public AudioClip bubbleBlowing;
	public AudioClip bubbleThrowing;
	private GameObject bubble;
	private PlayerMove playerMoveScript;
	private bool shooting;
	//private Transform mainCam;
	public int number_of_bubbles = 5;
	private GameObject mainCam;
	private CameraFollow cameraFollowScript;

	private bool _firstShot;
	private AudioSource asBubbleBlow;
	private AudioSource asBubbleThrow;

	// Use this for initialization
	void Start () {
		playerMoveScript = GetComponent<PlayerMove>();
		mainCam = GameObject.FindGameObjectWithTag("MainCamera");
		cameraFollowScript = mainCam.GetComponent<CameraFollow>();
		asBubbleBlow = gameObject.AddComponent<AudioSource>();
		asBubbleBlow.clip = bubbleBlowing;
		asBubbleThrow = gameObject.AddComponent<AudioSource>();
		asBubbleThrow.clip = bubbleThrowing;
	}

	void Update () {

		if(!GameManager.InSuspendedState)
		{
			if(Application.platform == RuntimePlatform.OSXWebPlayer)
			{
				if(InputManager.GetAxis("Blow") == 0) _firstShot = false;
				//First time i right click
				if (InputManager.GetAxis("Blow") < 0 && !_firstShot && playerMoveScript.grounded && number_of_bubbles > 0){
					InputManager.ResetInputAxes();
					ToggleBlowing ();
				}
			}
			else
			{
				if(InputManager.GetAxis("Shoot") == 0) _firstShot = false;
				//First time i right click
				if (InputManager.GetAxis("Shoot") < 0 && !_firstShot && playerMoveScript.grounded && number_of_bubbles > 0){
					InputManager.ResetInputAxes();
					ToggleBlowing ();
				}
			}
			

			//If im still holding down the button, grow the bubble
			if(shooting){
				if(bubble != null && current_scale < max_scale){
					bubble.transform.localScale = Vector3.one * current_scale;
					current_scale += growth_rate * Time.deltaTime;
					current_bubble_distance += growth_rate * Time.deltaTime; 

				    Vector3 currentLoc = this.transform.position + this.transform.forward * current_bubble_distance *0.5f;
					currentLoc.y += bubble_height + current_bubble_distance * 0.1f;
					bubble.transform.position = currentLoc;
				}
			}

			if (InputManager.GetAxis ("Shoot") > 0 && shooting){
				//makes it so the bubble has to be max size
				if(current_scale >= max_scale){
					//print ("FIRE");
					shooting = false;
					playerMoveScript.lockedMovement = false;
					cameraFollowScript.aiming = false;
					FireBubble();
					ResetBubbleBlowing();
					number_of_bubbles--;
					//print ("Number of bubbles left: " +number_of_bubbles);
				}
			}
		}
	}
		


	void ToggleBlowing(){
		shooting = !shooting;
		_firstShot = true;
		if(shooting){
			//print ("Shooting: ON");
			playerMoveScript.lockedMovement = true;
			cameraFollowScript.aiming = true;
			CreateNewBubble();
		}
		else{
			//print ("Shooting: OFF");
			Destroy(bubble);
			playerMoveScript.lockedMovement = false;
			cameraFollowScript.aiming = false;
			ResetBubbleBlowing();
		}
	}



	//Chris: creates new bubble new the players location
	void CreateNewBubble(){
		//Vector3 pos = this.transform.position;

		bubble = GameObject.Instantiate(Resources.Load("Bubble")) as GameObject;
		bubble.GetComponent<Bounce>().collisionEnter = false;
		bubble.transform.parent = this.transform;

		bubble.transform.position = this.transform.position + this.transform.forward * start_bubble_distance;
		bubble.transform.rotation = this.transform.rotation;
		Vector3 currentLoc = bubble.transform.position;
		currentLoc.y += bubble_height;
		
		bubble.transform.position = currentLoc;
		bubble.transform.localScale = Vector3.one;
		SoundManager.PlaySFX(asBubbleBlow);
	}


	void FireBubble(){
		if(bubble == null){
			ResetBubbleBlowing();
		}
		Rigidbody bubble_body = bubble.AddComponent<Rigidbody>();
		bubble_body.AddForce(mainCam.transform.forward * bubble_force);
		bubble.GetComponent<Bounce>().collisionEnter = true;
		if(bubble!=null)
		{
			SoundManager.PlaySFX(asBubbleThrow);
		}
	}


	//Chris: resets parameters so a new bubble can be blown
	void ResetBubbleBlowing(){
		if(bubble != null){
			current_scale = start_scale;
			current_bubble_distance = start_bubble_distance;
			bubble.transform.parent = this.transform.parent;
			bubble = null;
		}
	}

}
