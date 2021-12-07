using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public bool _isPaused = false;

    public GameObject menu;

    void Update() {

        if(Input.GetKeyDown(KeyCode.Escape)) {

            if(!_isPaused) {

                menu.SetActive(true);
                Time.timeScale = 0f;
                _isPaused = true;

            } else {

                menu.SetActive(false);
                Time.timeScale = 1f;
                _isPaused = false;

            }

        }

    }
    public void RestartPressed()
    {

        Scene current = SceneManager.GetActiveScene();

        if (current.name == "EndScreen" || current.name == "MainMenu")
        {

            SceneManager.LoadScene("Level1");

        }
        else
        {

            SceneManager.LoadScene(current.name);

        }

    }

    public void QuitPressed()
    {

        Application.Quit();

    }

}
