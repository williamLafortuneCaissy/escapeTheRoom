using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour {

	//List<Rigidbody2D> _inventory;
	private string _itemTag = "item";
	[SerializeField]
	private Door _door;

	//PUBLIC FUNCTIONS
	// fonction qui verifie si le joueur possede la cle
	// public bool keyInInventory() {
	// 	return _hasAKey;
	// }

	//PRIVATE FUNCTIONS
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// Used to add the key into the inventory
	/// <param name="other">the key</param>
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag==_itemTag) {
			_door.Open();
			Destroy(other.gameObject);
			//Debug.Log("you have the key");
			//_inventory.Add(other.GetComponent<Rigidbody2D>());
		}
	}
}
