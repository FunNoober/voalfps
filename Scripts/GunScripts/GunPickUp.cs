using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunPickUp : MonoBehaviour
{
    //Main
    public GameObject WeaponPlayer;
    public GameObject WeaponPickup;
    public GameObject Player;

    public int theWeaponIndex;
    public string weaponName;

    public GunPewPewScript gunScript;

    public Collider Hero;

    public GunsAreActive theGunManager;


    //All Weapons
    public GunPewPewScript[] weapons;

    void OnTriggerEnter()
    {
        SetParent();
    }

    public void SetParent()
    {
        if (Hero.gameObject.tag == "Player")
        {
            weapons = FindObjectsOfType<GunPewPewScript>();
            gunScript = WeaponPlayer.GetComponent<GunPewPewScript>();
            WeaponPlayer.transform.parent = Player.transform;
            WeaponPlayer.SetActive(true);
            theGunManager.weaponsAreActive[theWeaponIndex] = true;
            //Disable All Weapons
            foreach (GunPewPewScript theGun in weapons)
            {
                if (theGun.gameObject.name != weaponName)
                    theGun.gameObject.SetActive(false);
            }

            Destroy(gameObject);

        }
    }

}
