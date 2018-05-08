using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	void Start() {
		//DontDestroyOnLoad(gameObject);
		if (instance!=null) {
			Destroy(instance, 0);	
		} 
		instance = this;
		
				
	}

	public void PlayGame() {SceneManager.LoadScene("game");}
	public void Victory() {SceneManager.LoadScene("victory", LoadSceneMode.Additive);}
	public void Defeat() {SceneManager.LoadScene("defeat", LoadSceneMode.Additive);}
	public void Menu() {SceneManager.LoadScene("intro");
		
	}
}
