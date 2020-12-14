using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseCanvas;
    public GameObject resumeButton;
    public GameObject quitButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused)
            {
                ContinuePlaying();
            }
            else
            {
                StoppedPlaying();
            }
        }
    }

    public void ContinuePlaying()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused = false;
    }

    public void StoppedPlaying()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
    }

    public void mainMenuLoad()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

 
}
