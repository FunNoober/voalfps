using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevConsole_s : MonoBehaviour
{
    public GameObject devConsole;
    public bool consoleIsEnabled;

    public void h_Console(StarndardActions actions)
    {
        if (actions.StarndardInput.ConsoleKey.triggered)
        {
            if (consoleIsEnabled == false)
            {
                devConsole.SetActive(true);
                consoleIsEnabled = true;
                Cursor.lockState = CursorLockMode.None;
                return;
            }
            else
            {
                devConsole.SetActive(false);
                consoleIsEnabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                return;
            }
        }
    }
}
