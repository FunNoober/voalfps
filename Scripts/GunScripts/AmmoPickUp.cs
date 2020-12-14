using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
public GunPewPewScript gunScript;
public GameObject AmmoMag;
public GameObject theWeapon;
public float ammoToGive;

public Collider player;

public GunsAreActive theGunManager;
public int WeaponIndex;

void Start()
{

}

void Update()
{
    if(theGunManager.weaponsAreActive[WeaponIndex] == true)
    {

    }
}

void OnTriggerEnter()
{
    player = GameObject.FindWithTag("Player").GetComponent<Collider>();
    if(player.gameObject.tag == "Player" && theGunManager.weaponsAreActive[WeaponIndex] == true)
    {
    gunScript.reserveAmmo += ammoToGive;
    gunScript.CanReaload = true;
    Destroy(gameObject);
    }
}
}
