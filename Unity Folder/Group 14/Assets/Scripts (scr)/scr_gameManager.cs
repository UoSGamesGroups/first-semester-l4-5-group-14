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

	[Header("Puzzle Specific")]
	public bool isDragging = false;

	[Header("SpawnPlayer")]
	public Camera menuCamera;
	public GameObject playerPrefab;
	public Transform spawnPoint;
	public Canvas menuCanvas;
	public Canvas mainCanvas;

	private float speed = 1f;
	private float startTime;
	private float journeyLength;

	private scr_gameManager () {
		
	}

	void Start () {
		mainCanvas.enabled = false;
		menuCanvas.enabled = true;
		startTime = Time.time;
		journeyLength = Vector3.Distance(menuCamera.transform.position, spawnPoint.transform.position);
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
		if(Input.GetKeyDown(KeyCode.Space))
			SpawnPlayer();

		if (lockMouse) {
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = false;
		} else if (!lockMouse) {
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
		} else {
			Debug.LogError ("WTF? isInPuzzle bool error. Fix plz.");
		}

		if (puzzleComplete) {
			isDoorOpen = true;
		}
	}

	// Ideally move this part to some sort of Menu Manager.
	public void SpawnPlayer() {
		Debug.Log("SpawnPlayer()");
		mainCanvas.enabled = true;
		menuCanvas.enabled = false;
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		menuCamera.transform.position = Vector3.Lerp(menuCamera.transform.position, spawnPoint.transform.position, fracJourney);
		menuCamera.gameObject.transform.LookAt(spawnPoint);
		new WaitForSeconds(2);
		Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
		menuCamera.enabled = false;

	}
}
