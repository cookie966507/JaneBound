using UnityEngine;
using System.Collections;
using Assets.Scripts.Data;

#region Sabrina
public class Bang : MonoBehaviour {
	bool goingUp;
	float yOffset;
	Vector3 origin;

	private float _timer = 0f;
	private float _destroyTime = 2f;

	void Awake()
	{
		SoundManager.PlaySFX(this.GetComponent<AudioSource>());
	}
	// Use this for initialization
	void Start () {
		origin = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameManager.InSuspendedState)
		{
			if (goingUp) {
				yOffset += 0.0058f;
				transform.localPosition = new Vector3(origin.x,
				                                 origin.y + yOffset,
				                                 origin.z);
				if (yOffset > 0.05f) {
					goingUp = false;
				}
			} else {
				yOffset -= 0.0058f;
				transform.localPosition = new Vector3(origin.x,
				                                 origin.y + yOffset,
				                                 origin.z);
				if (yOffset < -0.05f) {
					goingUp = true;
				}
			}

			_timer += Time.deltaTime;
			if(_timer > _destroyTime)
			{
				_timer = 0f;
				Destroy(this.gameObject);
			}
		}
	}
}

#endregion