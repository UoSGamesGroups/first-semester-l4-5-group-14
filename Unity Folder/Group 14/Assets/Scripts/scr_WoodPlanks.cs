using UnityEngine;
using System.Collections;

public class scr_WoodPlanks : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (scr_gameManager.GameManager.puzzleComplete) {
            rb.constraints = RigidbodyConstraints.None;
        }
	}
}
