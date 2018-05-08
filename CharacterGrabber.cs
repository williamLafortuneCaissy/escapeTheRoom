using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrabber : MonoBehaviour {

	private List<Rigidbody2D> _accessibleItemsRb;
	private Rigidbody2D _grabbedItemRb;
	private FixedJoint2D _fixedJoint2D;
	private string _itemToGrabTag = "box";

	// Use this for initialization
	void Start () {
		_accessibleItemsRb = new List<Rigidbody2D>();
		_fixedJoint2D = GetComponent<FixedJoint2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && _accessibleItemsRb.Count!=0){
			GrabItem(_accessibleItemsRb[0]);
		}else if(Input.GetKeyUp(KeyCode.Space) && _grabbedItemRb!=null){
			ReleaseGrabbedItem();
		}
	}

	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag==_itemToGrabTag) {
			if (other.rigidbody!=null && !_accessibleItemsRb.Contains(other.rigidbody)) {
				_accessibleItemsRb.Add(other.rigidbody);
			}

		}
	}

	/// Sent when a collider on another object stops touching this
	/// object's collider (2D physics only).
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag==_itemToGrabTag){
			if(_accessibleItemsRb.Contains(other.rigidbody)){
				_accessibleItemsRb.Remove(other.rigidbody);
			}
		}
	}

	/// Used to grab the accessible item
	/// <param name="item">Accessible Rigidbody2D</param>
	void GrabItem(Rigidbody2D item) {
		_fixedJoint2D.enabled = true;
		_fixedJoint2D.connectedBody = item;
		item.bodyType = RigidbodyType2D.Dynamic;
		_grabbedItemRb = item;
	}

	/// let go of the item grabbed
	/// <param name="item">grabbed Rigidbody2D</param>
	void ReleaseGrabbedItem() {
		_grabbedItemRb.bodyType = RigidbodyType2D.Kinematic;
		_fixedJoint2D.enabled = false;
		_grabbedItemRb.velocity = Vector2.zero;
		_grabbedItemRb = null;
	}
}