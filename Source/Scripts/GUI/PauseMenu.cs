using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneNameConsts.LoadLevel(SceneNameConsts.MENU_NAME);
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
