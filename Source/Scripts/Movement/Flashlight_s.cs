using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_s : MonoBehaviour
{
    public bool flashlightEnabled;
    public GameObject flashlight;

    public void h_Flashlight(StarndardActions actions, PlayerMovementStats stats)
    {
        if (actions.StarndardInput.FlashLight.triggered && stats.hasFlashlight)
        {
            if (flashlightEnabled == false)
            {
                flashlight.gameObject.SetActive(true);
                flashlightEnabled = true;
                return;
            }

            if (flashlightEnabled == true)
            {
                flashlight.gameObject.SetActive(false);
                flashlightEnabled = false;
                return;
            }
        }
    }
}
