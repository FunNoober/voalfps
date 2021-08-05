using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume_s : MonoBehaviour
{
    public bool pauseActive;
    public GameObject pauseMenu;

    public void h_PauseResume(StarndardActions actions)
    {
        if (actions.StarndardInput.Pause.triggered)
            PauseResume();
    }

    private void PauseResume()
    {
        if (pauseActive == true)
        {
            pauseMenu.SetActive(false);
            pauseActive = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            return;
        }
        if (pauseActive == false)
        {
            pauseMenu.SetActive(true);
            pauseActive = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            return;
        }
    }
}
