using UnityEngine;
using System.Collections;

public class scr_bookTrigger : MonoBehaviour {

	/// <summary>
	/// This is the bookTrigger script which is used,
	/// to detect the collision between the book and bookTrigger.
	/// When the right colour book is colliding with the right trigger,
	/// once the player lets go of the button the book will snap into place.
	/// At the same time it will be flagged as complete, and score will be added.
	/// Once all the books are sorted, the puzzle will be complete.
	/// </summary>

	public string bookName = "BOOKNAME";
	public int bookLayer = 8;


	void Start () {
		gameObject.layer = bookLayer;
		Physics.IgnoreLayerCollision(bookLayer, bookLayer, true);
	}

	void OnTriggerStay (Collider coll) {
		if (coll.gameObject.tag == bookName) {
			if (scr_gameManager.GameManager.isDragging == false) {
				gameObject.transform.position = coll.transform.position;
				scr_puzzleManager.PuzzleManager.booksComplete += 1;
				bookName = "complete";
			}
		} 
	}
}
