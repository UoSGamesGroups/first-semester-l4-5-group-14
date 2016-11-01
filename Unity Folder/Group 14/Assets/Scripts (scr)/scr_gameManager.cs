using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class scr_gameManager : MonoBehaviour {

	public static scr_gameManager GameManager = null;

	[Header("Player Settings")]
	public bool isLightEnabled = false;

	[Header("General Game")]
	public bool isDoorOpen = false;
	public bool isInPuzzle = false;
	public bool puzzleComplete = false;

	[Header("Puzzle Specific")]
	public bool isDragging = false;

	private scr_gameManager () {
		
	}

	void Awake () {
		if (GameManager == null)
			GameManager = this;
		else if (GameManager != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	void Update () {
		if (!isInPuzzle) {
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = false;
		} else if (isInPuzzle) {
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
		} else {
			Debug.LogError ("WTF? isInPuzzle bool error. Fix plz.");
		}

		if (puzzleComplete) {
			isDoorOpen = true;
		}
	}
}
