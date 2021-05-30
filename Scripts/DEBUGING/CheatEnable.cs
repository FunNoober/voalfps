using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatEnable : MonoBehaviour
{
    public GameObject cheatCanvas;

    bool _IsEnabled = false;
    public KeyCode enableKey = KeyCode.Tilde;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            Debug.Log("Cheats Pressed");
            if(_IsEnabled == false)
            {
                Enable();
            }

            else
            {
                Disable();
            }
        }
    }

    void Enable()
    {
        cheatCanvas.SetActive(true);
        _IsEnabled = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Disable()
    {
        cheatCanvas.SetActive(false);
        _IsEnabled = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
