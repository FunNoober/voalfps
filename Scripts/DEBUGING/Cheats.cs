using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheats : MonoBehaviour
{
    public GunPewPewScript[] weapons;


    public GameObject cheatMenu;
    public GameObject playerCanvas;
    public bool inCheat;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (inCheat)
                DisableMenu();
            else
                EnableMenu();
        }
    }

    public void GiveAmmo()
    {
        foreach(GunPewPewScript gun in weapons)
        {
            gun.maxAmmo = 999999;
            gun.currentAmmo = 999999;
            gun.CanReaload = true;
        }
    }

    void EnableMenu()
    {
        cheatMenu.SetActive(true);
        playerCanvas.SetActive(false);
        inCheat = true;
        Cursor.lockState = CursorLockMode.None;
    }
    void DisableMenu()
    {
        cheatMenu.SetActive(false);
        playerCanvas.SetActive(true);
        inCheat = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
