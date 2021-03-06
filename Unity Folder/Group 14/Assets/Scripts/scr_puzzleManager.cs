﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class scr_puzzleManager : MonoBehaviour {

	public static scr_puzzleManager PuzzleManager = null;

	[Header("Puzzle GUI")]
	public Text scoreText;
	public Text completeText;

    public int loadSceneID = 0;

    [HideInInspector]
    public int booksCount = 0;
    public int booksComplete = 0;

    void Start () {
        scr_gameManager.GameManager.isInPuzzle = true;
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
		scoreText.text = booksComplete + "/" + booksCount;
	}

	void PuzzleCompleted () {
		scr_gameManager.GameManager.puzzleComplete = true;
		completeText.enabled = true;
		StartCoroutine(PuzzleEnd());
	}

    IEnumerator PuzzleEnd() {
        yield return new WaitForSeconds(5);
        scr_gameManager.GameManager.isInPuzzle = true;
        scr_gameManager.GameManager.puzzleComplete = true;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
