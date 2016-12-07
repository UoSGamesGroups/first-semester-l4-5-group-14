using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class scr_gameManager : MonoBehaviour {

	public static scr_gameManager GameManager = null;

    [Header("Bools")]
	public bool isLightEnabled = false;
    public bool lockMouse = false;
    public bool isInPuzzle = false;
    public bool isSpawned = false;
    public bool isDragging = false;
	public bool isDoorOpen = false;
	public bool puzzleComplete = false;
    public bool inActionTrigger;

	[Header("Objects")]
    public Transform spawnPoint;
	public GameObject playerPrefab;
    public Text doorLocked;
    public Text interactKey;
    public Text pressSpace;

    [HideInInspector]
    public Vector3 playerPos = Vector3.zero;

    private Vector3 playerRot = new Vector3( 0, 180, 0 );

	private scr_gameManager () {
		
	}

	void Start () {
        if (!isInPuzzle) {
            doorLocked.enabled = false;
            interactKey.enabled = false;
            lockMouse = false;
        }

        if (!isSpawned && !isInPuzzle)
            playerPos = spawnPoint.transform.position;
	}

	void Awake () {
		if (GameManager == null)
			GameManager = this;
		else if (GameManager != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && !isSpawned)
			SpawnPlayer();

        #region MouseLock
		if (!isInPuzzle) {
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = false;
		} else if (isInPuzzle)  {
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
		} else {
            return;
		}
        #endregion

        #region GUIDetection
        if (inActionTrigger && !isInPuzzle) {
            interactKey.enabled = true;
        } else if (!isInPuzzle) {
            interactKey.enabled = false;
        }
        #endregion
	}

    public void SavePosition(Vector3 playerPosition) {
        playerPos = playerPosition;
    }

	public void SpawnPlayer() {
        if (!isSpawned) {
            Debug.Log( "Spawn New Player" );

            new WaitForSeconds( 2 );
            MapManager.mapManager.menuCamera.SetActive( false );
            pressSpace.enabled = false;
            Instantiate( playerPrefab, playerPos, Quaternion.Euler( playerRot.x, playerRot.y, playerRot.z ));
            isSpawned = true;
        } else if (isSpawned) {
            Debug.Log( "Load Player" );

            new WaitForSeconds( 2 );
            MapManager.mapManager.menuCamera.SetActive( false );
            pressSpace.enabled = false;
            Instantiate( playerPrefab, playerPos, Quaternion.Euler(playerRot.x, playerRot.y, playerRot.z));
        }
	}
}
