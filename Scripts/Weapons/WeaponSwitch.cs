using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int currentWeapon = 0;

    public StarndardActions actions;

    private void Awake()
    {
        actions = new StarndardActions();
        Select();
    }

    #region

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    #endregion

    private void Update()
    {
        int beforeCurrentWeapon = currentWeapon;

        if (actions.StarndardInput.Switch.ReadValue<float>() == 1) 
        {
            if (currentWeapon >= transform.childCount - 1)
                currentWeapon = 0;
            else
                currentWeapon++;
        }

        if(beforeCurrentWeapon != currentWeapon) { Select(); }
    }

    public void Select()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == currentWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
