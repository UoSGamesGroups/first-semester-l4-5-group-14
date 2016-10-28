using UnityEngine;
using UnityEngine.UI;					// Do the UI stuff using external scripts, its not required to be here.
using UnityEngine.SceneManagement;		// Later remove as its not needed here; call using external script or GameManager.
using System.Collections;

public class scr_playerController : MonoBehaviour {

	/// <summary>
	/// Player Controller script that handles movement,
	/// rotation and controls for the player.
	/// All the variables can be adjusted in the inspector window.
	/// This is very simple, and can be/should be replaced later,
	/// by a better system if needed.
	/// </summary>

	[Header("Player Settings")]
	public float speed = 6f;
	public float jumpSpeed = 8f;
	public float gravity = 20f;		// Gravity can be changed, based on the level.
	public bool inPuzzleTrigger = false;
	public int currentLevel = 0;
	public int levelToLoad = 0;

    [Header("Key Controls")]
    public string interactKey = "E";

	[Header("GUI Settings")]
	public Text actionKeyText;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	void Start () {
		controller = GetComponent<CharacterController> ();
		inPuzzleTrigger = false;
		actionKeyText.enabled = false;
	}

	void Awake() {
		currentLevel = SceneManager.GetActiveScene().buildIndex;

		levelToLoad = currentLevel += 1;
	}

	void Update () {
		// is the controller grounded?
		if (controller.isGrounded) {
			#region Movement
			moveDirection = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);

			moveDirection *= speed;
			#endregion

			#region Jumping
			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
			#endregion
		}

		if (inPuzzleTrigger && Input.GetKeyDown(KeyCode.E)) {
			Debug.Log("Press F to pay respects.");
			SceneManager.LoadScene (levelToLoad);
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

        // Die
        if (transform.position.y <= -5) {
            StartCoroutine(Die());
        }

	}

    IEnumerator Die() {
        Debug.Log("Dead");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

	#region Detect Puzzle Trigger
	void OnTriggerEnter(Collider coll) {
		Debug.Log("Current Level: " + currentLevel + ". Level to Load: " + levelToLoad);
		actionKeyText.enabled = true;
		inPuzzleTrigger = true;
	}

	void OnTriggerExit(Collider coll) {
		actionKeyText.enabled = false;
        actionKeyText.text = "Press '" + interactKey + "' to interact.";
		inPuzzleTrigger = false;
	}
	#endregion
}
