using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class scr_gameManager : MonoBehaviour {

	public static scr_gameManager GameManager = null;

	[Header("Player Settings")]
	public bool isLightEnabled = false;

	[Header("General Game")]
	public bool isDoorOpen = false;
	public bool lockMouse = false;
	public bool puzzleComplete = false;
    public bool isInPuzzle = false;
    public bool isSpawned = false;

	[Header("Puzzle Specific")]
	public bool isDragging = false;

	[Header("SpawnPlayer")]
	public GameObject playerPrefab;
	public Transform spawnPoint;
	public Canvas mainCanvas;
    public GameObject pressSpace;

    private float speed = 1f;
	private float startTime;
	private float journeyLength;

	private scr_gameManager () {
		
	}

	void Start () {
        Vector3 spawnPoint = new Vector3(0, 1, 0);
        pressSpace = GameObject.Find("pressSpace");
        if (mainCanvas != null)
		    mainCanvas.enabled = false;
        startTime = Time.time;
		lockMouse = false;
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

		if (!isInPuzzle) {
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = false;
		} else if (isInPuzzle)  {
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
		} else {
            return;
		}

        if (isInPuzzle)
            lockMouse = false;

		if (puzzleComplete) {
			isDoorOpen = true;
		}
	}

	// Ideally move this part to some sort of Menu Manager.
	public void SpawnPlayer() {
        isSpawned = true;
        Debug.Log("SpawnPlayer()");

        if (mainCanvas != null)
		    mainCanvas.enabled = true;
        if (pressSpace != null)
            pressSpace.SetActive(false);

		new WaitForSeconds(2);
		Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
	}
}
