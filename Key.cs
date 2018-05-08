using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	[SerializeField]
	private Door _door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Used when the Character takes the key
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("You took the key");
		// open door
		_door.Open();
		Destroy(this.gameObject);
	}
}
