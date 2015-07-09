using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BubbleNumber : MonoBehaviour {


	Text t;
	BubbleBlowing bubbleBlowing;
	// Use this for initialization
	void Start () {
	
		t = gameObject.GetComponent<Text>();
		bubbleBlowing = GameObject.FindGameObjectWithTag("Player").GetComponent<BubbleBlowing>();
	}
	
	// Update is called once per frame
	void Update () {
		t.text =  bubbleBlowing.number_of_bubbles.ToString();
			//bb.number.ToString();
	}
}
