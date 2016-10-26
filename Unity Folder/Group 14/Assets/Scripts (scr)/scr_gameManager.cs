using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class scr_gameManager : MonoBehaviour {

	public bool isInPuzzle = false;
	public int currentLevel;

	// Use this for initialization
	void Start () {
		currentLevel = SceneManager.GetActiveScene ().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
