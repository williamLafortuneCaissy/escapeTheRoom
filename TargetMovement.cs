using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour {

	[SerializeField]
	private Transform _characterPos;
	[SerializeField]
	private float _speed;
	private Rigidbody2D _rigidbody;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	void FixedUpdate() {
		//get rotation
		float deltaY = _characterPos.position.y - transform.position.y;
		float deltaX = _characterPos.position.x - transform.position.x;
		_rigidbody.velocity = new Vector2(deltaX, deltaY).normalized * _speed;
	}
}
