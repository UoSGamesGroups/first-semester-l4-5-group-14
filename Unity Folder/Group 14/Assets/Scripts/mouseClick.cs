using UnityEngine;
using System.Collections;

public class mouseClick : MonoBehaviour {

    //public Transform raycastHit;

    float distance = 11f;
    //float rotSpeed = 1f;

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        //float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        //transform.Rotate(Vector3.up, -rotX);
        //transform.Rotate(Vector3.right, rotY);

        transform.position = objPosition;
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            scr_gameManager.GameManager.isDragging = true;
        } else {
            scr_gameManager.GameManager.isDragging = false;
        }

        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out hit))
        //{
        //    Debug.DrawLine(ray.origin, ray.direction, Color.blue);
        //    Debug.Log(hit.transform.name);
            //raycastHit = hit.transform;
        //}
    }
}
