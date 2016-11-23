using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	void OnButtonClick () {
		
	}

	public void NewGame () {
		scr_gameManager.GameManager.SpawnPlayer();
		Debug.Log("NEW GAME");
	}
}