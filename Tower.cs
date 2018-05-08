using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField]
	private Transform _targetTransform;
	[SerializeField]
	private CharacterMovement _characterScript;
	[SerializeField]
	private Collider2D _characterCollider;
	[SerializeField]
	private LayerMask _RaycastLayerMask;

	private RaycastHit2D _raycastHit;
	private LineRenderer _laser;
	private Rigidbody2D _rigidbody;
	private int _laserMaxLength = 32;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D>();
		_laser = GetComponent<LineRenderer>();
		_characterCollider = _characterCollider.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	// used to determine the tower's rotation and laser's position
	void Update () {
		//get angle
		float deltaY = _targetTransform.position.y - transform.position.y;
		float deltaX = _targetTransform.position.x - transform.position.x;
		Laser(deltaX, deltaY);
		float angle = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;
		//rotate tower
		_rigidbody.rotation = angle;
		
	}

	// Draw the tower's laser
	private void Laser(float deltaX, float deltaY) {
	 	Vector2 direction = new Vector2(deltaX, deltaY);
	 	_raycastHit = Physics2D.Raycast(transform.position, direction, _laserMaxLength, _RaycastLayerMask, 0);
		// Debug.DrawRay(transform.position, direction, Color.green);
		
		// set laser's initial point
		_laser.SetPosition(0, transform.position);
		if (_raycastHit.collider == _characterCollider) {
			// character is hit and dies
			_characterScript.Kill();
		}
		
		// set laser's second point (draw laser)
		_laser.SetPosition(1, _raycastHit.point);
	}
}
