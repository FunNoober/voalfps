using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeToDebugMode : MonoBehaviour
{
    Toggle selfToggle;
    public void ChangeDebugStatus()
    {
        selfToggle = GetComponent<Toggle>();
        AccesDebugStuff.inDevMode = selfToggle.isOn;
    }
}
