using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadDebugScript : MonoBehaviour
{
    public GameObject testingLevelButton;

    private void Update()
    {
        testingLevelButton.SetActive(AccesDebugStuff.inDevMode);
    }
}
