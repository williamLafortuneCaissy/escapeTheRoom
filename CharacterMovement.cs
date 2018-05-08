using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	[SerializeField]
	private float _speed;
	
	private Rigidbody2D _rigidbody;
	private BoxCollider2D _collider;
	private Animator _animator;
	private string _deadState = "isDead";
	private string _WalkingState = "isWalking";

	private GameManager _gameManager;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.Find("gameManager").GetComponent<GameManager>();
		_rigidbody = GetComponent<Rigidbody2D>();
		_collider = GetComponent<BoxCollider2D>();
		_animator =  GetComponent<Animator>();
	}

	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	void FixedUpdate() {
		//get rotation
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float deltaY = mousePos.y - transform.position.y;
		float deltaX = mousePos.x - transform.position.x;
		float angle = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;
		_rigidbody.rotation = angle;
		
		//stops movement when close to mouse
		float distance = Vector2.Distance(mousePos, transform.position);
		if (distance > _collider.size.x) {
			_rigidbody.velocity = new Vector2(deltaX, deltaY).normalized * _speed;
			_animator.SetBool(_WalkingState, true);
		} else {
			_rigidbody.velocity = new Vector2(0,0);
			_animator.SetBool(_WalkingState, false);
		}
	}

	// the character dies if it's hit by Tower's lazer
	public void Kill() {
		Stop();
		_gameManager.Defeat();
		_animator.SetBool(_deadState, true);
	}

	public void Stop(){
		_animator.SetBool(_WalkingState, false);
		_collider.enabled = false;
		_rigidbody.bodyType = RigidbodyType2D.Static;
		_rigidbody.rotation = 0;
		this.enabled = false;
	}
}
