using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevSystem : MonoBehaviour
{

    public GameObject Weapons;
    public GameObject MainCanvas;
    public GameObject Flashlight; 
    public GameObject AllLights;

    public GunPewPewScript[] theGuns;
    
    public string enableText = ";";

    public bool isEnabled = false;
    public bool isDisabled = true;

    public GameObject CheatCanvas;

    public KeyCode turnCheatsOff;
    public KeyCode turnCheatsOn;


    void Update()
    {
        if(Input.GetKeyDown(turnCheatsOn))
        {
            CheatCanvas.SetActive(true);
            MainCanvas.SetActive(false);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }

        if(Input.GetKeyDown(turnCheatsOff))
        {
            CheatCanvas.SetActive(false);
            MainCanvas.SetActive(true);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void GiveAllAmmo()
    {
        foreach(GunPewPewScript gun in theGuns)
        {
            gun.currentAmmo = 99;
            gun.reserveAmmo = 99f;
            gun.CanReaload = true;
        }
    }

    public void WeaponsOff()
    {
    Weapons.SetActive(false);
    MainCanvas.SetActive(false);
    Flashlight.SetActive(false);
    }

    public void LightsOff()
    {
    AllLights.SetActive(false);
    }

    public void WeaponsOn()
    {
    Weapons.SetActive(true);
    MainCanvas.SetActive(true);
    Flashlight.SetActive(true);
    }

    public void LightsOn()
    {
    AllLights.SetActive(true);
    }
}
