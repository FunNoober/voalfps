using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveAdmin : MonoBehaviour
{
    public AdminAccess adminScript;

    void OnTriggerEnter()
    {
        adminScript.hasAdmin = true;
    }
}
