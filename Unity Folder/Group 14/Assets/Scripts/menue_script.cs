using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menue_script : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {

            print("pressed");
            SceneManager.LoadScene("scn_mainNew");

        }
    }

}