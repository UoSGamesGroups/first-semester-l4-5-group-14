using UnityEngine;
using System.Collections;

public class scr_DrawOutline : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGizmosDraw () {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position, new Vector3(0.5f,2f,1f));
	}
}
