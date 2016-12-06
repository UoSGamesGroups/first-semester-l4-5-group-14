using UnityEngine;
using System.Collections;

public class scr_followMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
	}
}
