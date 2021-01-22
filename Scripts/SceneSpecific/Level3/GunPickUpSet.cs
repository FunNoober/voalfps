using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUpSet : MonoBehaviour
{
    public Level3Manager gameMaster;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameMaster.weaponPickedUp = true;
        }
    }
}
