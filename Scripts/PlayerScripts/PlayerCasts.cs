using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasts : MonoBehaviour
{
    public GameObject weaponSelectMenu;
    public bool inMenu;
    public GameObject infoTooltip;

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
                infoTooltip.SetActive(true);
            else
                infoTooltip.SetActive(false);
        }
    }

    void ActivateMenu()
    {
        weaponSelectMenu.SetActive(true);
        inMenu = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    void DisableMenu()
    {
        weaponSelectMenu.SetActive(false);
        inMenu = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}
