using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

	private Animator _animator;
	private string _BoolOpen = "isOpen";

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// used to open the Gate
	public void Open() {
		_animator.SetBool(_BoolOpen, true);
	}

	// used to close the Gate
	public void Close() {
		_animator.SetBool(_BoolOpen, false);
	}
}
