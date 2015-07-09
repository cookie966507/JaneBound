using UnityEngine;
using System.Collections;

public class Bang : MonoBehaviour {
	bool goingUp;
	float yOffset;
	Vector3 origin;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 2f);
		origin = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
