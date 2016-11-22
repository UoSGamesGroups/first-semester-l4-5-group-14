using UnityEngine;
using System.Collections;

public class mouseClick : MonoBehaviour {

    	float distance = 11f;
        float speed = 1f;

        float rotSpeed = 10f;


    void OnMouseDrag() {
     		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        	Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

             float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
             float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

             transform.Rotate(Vector3.up, -rotX);
             transform.Rotate(Vector3.right, rotY);

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
