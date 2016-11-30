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
    public Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
        gameObject.layer = bookLayer;
    }

    void Update() {
        if (scr_gameManager.GameManager.isDragging) {
            // WHEN SCROLLING, MOVE BOOK EITHER FRONT OR BACK.
        }
    }

    void OnTriggerStay (Collider coll) {
        if (coll.gameObject.tag == bookName)
        {
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            if (scr_gameManager.GameManager.isDragging == false) {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                gameObject.transform.position = coll.transform.position;
                float currPosX = transform.position.x;
                float currPosY = transform.position.y;
                gameObject.transform.position =new Vector3(currPosX, currPosY, 1.5f);
                scr_puzzleManager.PuzzleManager.booksComplete += 1;
                bookName = "complete";
            }
        }
        else {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
