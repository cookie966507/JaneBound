using UnityEngine;
using System.Collections;
//using TeamUtility.IO;

namespace Assets.Scripts.Player
{
	public class PlayerMovement : PlayerControllerObject
	{
		private float _moveSpeed = 5f;
		private float _slipSpeed = 3f;
		private float _rotateSpeed = 100f;
		private float _jumpForce = 10f;
		private bool _grounded = true;
		private float _maxSlope = 70f;
		private Animator _anim;
		private AnimatorStateInfo _currentBaseState;
		private Rigidbody _rigidbody;

		private Vector3 _slipVector;

		public GameObject _ragdoll;
		public GameObject _model;


		static int _idleState = Animator.StringToHash("Base Layer.Idle");	
		static int _moveState = Animator.StringToHash("Base Layer.Locomotion");
		static int _walkBackState = Animator.StringToHash("Base Layer.WalkBack");
		static int _jumpState = Animator.StringToHash("Base Layer.Jump");
		static int _fallState = Animator.StringToHash("Base Layer.Fall");
		static int _slipState = Animator.StringToHash("Base Layer.Slip");

		void OnCollisionEnter(Collision _col)
		{
			foreach(ContactPoint _contact in _col.contacts)
			{
				if(Vector3.Angle(_contact.normal, Vector3.up) < _maxSlope)
				{
					_grounded = true;
					_anim.SetBool("Jump", false);
				}
			}
		}

		//setting up events
		void OnEnable()
		{
			PlayerLife.PlayerDie += EnableRagdoll;
		}
		
		void OnDisable()
		{
			PlayerLife.PlayerDie -= EnableRagdoll;
		}

		void Start()
		{
			_anim = this.GetComponent<Animator>();
			_rigidbody = this.GetComponent<Rigidbody>();
		}

		public override void Run ()
		{
			if(_currentBaseState.fullPathHash == _fallState)
			{
				_anim.SetBool("Jump", false);
				_anim.SetBool("Land", _grounded);
			}
		}

		public override void FixedRun ()
		{
//			float _h = InputManager.GetAxis("Horizontal");
//			float _v = InputManager.GetAxis("Vertical");

			if(_currentBaseState.fullPathHash != _slipState)
			{
				float _h = Input.GetAxis("Horizontal");
				float _v = Input.GetAxis("Vertical");

				_anim.SetFloat("Speed", _v);
				_anim.SetFloat("Direction", _h);

				_currentBaseState = _anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation
			}
			if(_currentBaseState.fullPathHash == _slipState)
			{
				_rigidbody.MovePosition(transform.position + _slipVector * Time.deltaTime * _slipSpeed);
			}
//			if(InputManager.GetButtonDown("Jump"))
			if(Input.GetButtonDown("Jump"))
			{
				if (_grounded)
				{
					_anim.SetBool("Jump", true);
					_grounded = false;
					_rigidbody.AddRelativeForce(Vector3.up * _jumpForce, ForceMode.Impulse);
				}
			}
		}

		public void Slip(Vector3 _direction)
		{
			_anim.SetBool("Slip", true);
			_slipVector = _direction;
			_anim.speed = 1.5f;
		}

		public void StopSlipping()
		{
			_anim.SetBool("Slip", false);
			_anim.speed = 1.0f;
		}

		public void EnableRagdoll()
		{
			_rigidbody.isKinematic = true;
			_anim.enabled = false;
			this.GetComponent<CapsuleCollider>().enabled = false;

			_ragdoll.transform.position = this.transform.position;
			_ragdoll.transform.rotation = this.transform.rotation;
			_model.gameObject.SetActive(false);
			_ragdoll.gameObject.SetActive(true);
		}
	}
}
