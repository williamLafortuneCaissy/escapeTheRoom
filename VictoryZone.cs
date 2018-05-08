using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryZone : MonoBehaviour {

	private GameManager _gameManager;
	private CharacterMovement _character;

	void Start() {
		_gameManager = GameObject.Find("gameManager").GetComponent<GameManager>();
		_character = GameObject.Find("character").GetComponent<CharacterMovement>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		_character.Stop();
		_gameManager.Victory();
	}
}
