using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

    public static MapManager mapManager = null;

    void Awake() {
        if (mapManager == null)
            mapManager = this;
        else if (mapManager != this)
            Destroy( gameObject );
    }

    public GameObject menuCamera;
    public GameObject cinematicCamera;

	// Use this for initialization
	void Start () {
        if (scr_gameManager.GameManager.isSpawned) {
            menuCamera.SetActive( false );
            cinematicCamera.SetActive( false );
            StartCoroutine( LoadPlayer() );
        }
	}

    IEnumerator LoadPlayer() { 
        cinematicCamera.SetActive( true );
        yield return new WaitForSeconds( 5 );
        cinematicCamera.SetActive( false );
        scr_gameManager.GameManager.SpawnPlayer();
    }
}
