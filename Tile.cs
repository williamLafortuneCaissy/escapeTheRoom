using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	[SerializeField]
	private Gate _gate;

	private string _boxTag = "box";
	private bool _tileStillPressed;

	/// Opens the Gate 
	void OnTriggerEnter2D(Collider2D other) {
		_gate.Open();
		if (other.tag == _boxTag) {
			_tileStillPressed = true;
		}
	}

	/// verify if the box is on Tile
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == _boxTag) {
			_tileStillPressed = false;
		}
	}

	public bool IsPressed() {return _tileStillPressed;}
}

