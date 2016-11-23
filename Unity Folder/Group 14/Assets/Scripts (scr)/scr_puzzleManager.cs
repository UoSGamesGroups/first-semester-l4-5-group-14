using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class scr_puzzleManager : MonoBehaviour {

	public static scr_puzzleManager PuzzleManager = null;

	[Header("Books")]
	public int booksCount = 0;
	public int booksComplete = 0;

	[Header("Puzzle GUI")]
	public Text scoreText;
	public Text completeText;

	void Start () {
		GameObject[] books = GameObject.FindGameObjectsWithTag("book");

		foreach (GameObject go in books) {
			booksCount += 1;
		}

		scr_gameManager.GameManager.lockMouse = true;
		completeText.enabled = false;
	}

	void Awake () {
		if (PuzzleManager == null)
			PuzzleManager = this;
		else if (PuzzleManager != this)
			Destroy(gameObject);
	}

	void Update () {
		if (booksComplete == booksCount) {
			PuzzleCompleted();
		}
		scoreText.text = "SORTED: " + booksComplete + "/" + booksCount;
	}

	void PuzzleCompleted () {
		scr_gameManager.GameManager.puzzleComplete = true;
		completeText.enabled = true;
		StartCoroutine(PuzzleEnd());
	}

	IEnumerator PuzzleEnd () {
		yield return new WaitForSeconds (5);
		scr_gameManager.GameManager.lockMouse = false;
		scr_gameManager.GameManager.puzzleComplete = true;
		SceneManager.LoadScene ("scn_test01");
	}
}
