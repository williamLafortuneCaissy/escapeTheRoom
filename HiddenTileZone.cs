using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTileZone : MonoBehaviour {

	[SerializeField]
	private Gate _gate;
	[SerializeField]
	private Tile _tile;

	/// Closes the Gate if there's no box on the tile
	void OnTriggerExit2D(Collider2D other) {
		//verify if the box is onthe Tile
		if (!_tile.IsPressed()) {
			_gate.Close();
		}
	}
}
	


