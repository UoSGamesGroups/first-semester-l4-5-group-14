using UnityEngine;
using UnityEngine.UI;					// Do the UI stuff using external scripts, its not required to be here.
using UnityEngine.SceneManagement;			// Later remove as its not needed here; call using external script or GameManager.
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
    public int currentLevel = 0;
    public int levelToLoad = 0;
    public GameObject playerLight;
    //public GameObject dustParticles;

    [Header("GUI")]
    public GameObject actionKeyText;
    public GameObject doorLockedText;
    //public GameObject pressSpace;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start () {
        actionKeyText = GameObject.Find("actionKeyText");
        doorLockedText = GameObject.Find("doorLockedText");
        controller = GetComponent<CharacterController> ();

        if(actionKeyText != null)
            actionKeyText.SetActive(false);

        if(doorLockedText != null)
            doorLockedText.SetActive(false);


        if (scr_gameManager.GameManager.isLightEnabled) {
            playerLight.SetActive(true);
            //dustParticles.SetActive(true);
        } else {
            playerLight.SetActive(false);
            //dustParticles.SetActive(false);
        }
        
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



        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

            if (transform.position.y <= -5) {
                StartCoroutine(Die());
        }

        if (Input.GetKeyDown(KeyCode.L) && !scr_gameManager.GameManager.isLightEnabled) {
            scr_gameManager.GameManager.isLightEnabled = true;
            playerLight.SetActive(true);
            }
        else if (Input.GetKeyDown(KeyCode.L) && scr_gameManager.GameManager.isLightEnabled) {
            scr_gameManager.GameManager.isLightEnabled = false;
            playerLight.SetActive(false);
            }
    }
    
    IEnumerator Die() {
            Debug.Log("Dead");
            yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    #region Detect Triggers
    void OnTriggerStay(Collider coll) {
        if (coll.gameObject.tag == "puzzleTrigger") {
            actionKeyText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) {
				scr_gameManager.GameManager.lockMouse = true;
                SceneManager.LoadScene (levelToLoad);
            }
        }

        if (coll.gameObject.tag == "doorTrigger") {
            if (scr_gameManager.GameManager.isDoorOpen) {
                actionKeyText.SetActive(true);
            } else if (!scr_gameManager.GameManager.isDoorOpen) {
                doorLockedText.SetActive(true);
            }
        }

    }

    void OnTriggerExit(Collider coll) {
        actionKeyText.SetActive(false);
        doorLockedText.SetActive(false);
    }
    #endregion
}
