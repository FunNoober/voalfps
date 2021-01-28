using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickSet : MonoBehaviour
{
    public int id;
    public event System.Action giveAmmo;

    private void OnTriggerEnter(Collider other)
    {              
        GiveAmmo();
    }

    void GiveAmmo()
    {
        if (giveAmmo != null)
            giveAmmo();
    }
}
