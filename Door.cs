using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// Verify if the Character has the key to open this door
	/// <param name="other">The door to open</param>
	void OnCollisionEnter2D(Collision2D other) {
		// if character has a key
		// 	Open()
		// else
		// 	you need a key
	}

	// Used to open the door
	public void Open() {
		transform.Rotate(0, 0, 90);
	}
}
