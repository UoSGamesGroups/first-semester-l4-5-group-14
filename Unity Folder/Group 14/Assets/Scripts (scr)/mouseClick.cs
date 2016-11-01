using UnityEngine;
using System.Collections;

public class mouseClick : MonoBehaviour {

    	float distance = 9.5f;

	void OnMouseDrag() {
     		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        	Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        	transform.position = objPosition;
    	}

	void Update () {
		if (Input.GetMouseButton(0)) {
			scr_gameManager.GameManager.isDragging = true;
		} else {
			scr_gameManager.GameManager.isDragging = false;
		}
	}
}
