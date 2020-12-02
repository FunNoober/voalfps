using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBetweenWeapons : MonoBehaviour
{
    //Script Allows Switching Between Different Weapons. Pew Pew!

    public int currentWeapon = 0;

    void Start()
    {
        SelectWeapon();
    }


    void Update()
    {
        int previousSelectedWeapon = currentWeapon;
        
        //Scroll Up
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentWeapon >= transform.childCount - 1)
                currentWeapon = 0;
            else
                currentWeapon++;
        }

        //Scroll Down
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentWeapon <= 0)
                currentWeapon = transform.childCount - 1;
            else
                currentWeapon--;
        }



        if (previousSelectedWeapon != currentWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == currentWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
