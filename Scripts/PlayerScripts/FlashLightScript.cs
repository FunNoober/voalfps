using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightScript : MonoBehaviour
{
    public bool lightIsOn = false;

    public GameObject theLight;

    public KeyCode OnOffKey;

    void Update()
    {
        if(Input.GetKeyDown(OnOffKey))
        {
        if(lightIsOn == false)
        {
            LightOn();
        }
        else
        {
            LightOff();
        }
        }
    }

    public void LightOff()
    {
        theLight.SetActive(false);
        lightIsOn = false;
    }

    public void LightOn()
    {
        theLight.SetActive(true);
        lightIsOn = true;
    }
}
