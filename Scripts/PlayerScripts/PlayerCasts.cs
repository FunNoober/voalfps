using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasts : MonoBehaviour
{
    public GameObject weaponSelectMenu;
    public GameObject healthShieldMenu;
    public bool inMenu;
    public bool inHealthShieldMenu;
    public GameObject infoTooltip;
    public GameObject healthInfoTooltip;

    private void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f))
            {
                if(hit.collider.tag == "WeaponCrate")
                {
                    if(!inMenu)
                    {
                        ActivateMenu();
                        return;
                    }
                }
                if(hit.collider.tag == "HealthCrate")
                {
                    ActivateDisableMenu();
                }
            }
            if(inMenu)
            {
                DisableMenu();
            }

        }
    }

    private void FixedUpdate()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, 5f))
        {
            if (hitInfo.collider.CompareTag("WeaponCrate"))
            {
                infoTooltip.SetActive(true);
                return;
            }
            else
            {
                infoTooltip.SetActive(false);
            }
            
            
            if (hitInfo.collider.CompareTag("HealthCrate"))
            {
                healthInfoTooltip.SetActive(true);
                return;
            }
            else
            {
                healthInfoTooltip.SetActive(false);
            }
        }
    }

    void ActivateMenu()
    {
        weaponSelectMenu.SetActive(true);
        inMenu = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void DisableMenu()
    {
        weaponSelectMenu.SetActive(false);
        inMenu = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    void ActivateDisableMenu()
    {
        if(inHealthShieldMenu)
        {
            healthShieldMenu.SetActive(false);
            inHealthShieldMenu = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
        if(!inHealthShieldMenu)
        {
            healthShieldMenu.SetActive(true);
            inHealthShieldMenu = true;
            Cursor.lockState = CursorLockMode.None;
            return;
        }
    }
}
