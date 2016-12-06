using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class changeLevel : MonoBehaviour {

    void OnTriggerStay() {
        if (scr_gameManager.GameManager.isDoorOpen && Input.GetKeyDown(KeyCode.E)) {
            SceneManager.LoadScene("scn_mainNew");
        }
    }
}
