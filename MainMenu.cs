using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private bool restart;

    // Start is called before the first frame update
    void Start()
    {
        restart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("SampleScene");
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                SceneManager.LoadScene("HardMode");
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("TimeAttack");
            }

        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}

