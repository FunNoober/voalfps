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

    public GunPewPewScript[] gunsFound;

    public int WeaponIndex;

    public string weaponName;

    public event System.Action giveAmmo;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
        theGunManager = FindObjectOfType<GunsAreActive>();
    }

    void Update()
    {
        if (theGunManager.weaponsAreActive[WeaponIndex] == true)
        {

        }
    }

    void OnTriggerEnter()
    {
        
        player = GameObject.FindWithTag("Player").GetComponent<Collider>();

        gunsFound = FindObjectsOfType<GunPewPewScript>();

        foreach (GunPewPewScript theGun in gunsFound)
        {
            gunScript = theGun.gameObject.GetComponent<GunPewPewScript>();
            if (theGun.gameObject.name == weaponName && gunScript != null)
            {
                GiveAmmo();
            }
        }


    }

    void GiveAmmo()
    {
        if (player.gameObject.tag == "Player" && theGunManager.weaponsAreActive[WeaponIndex] == true)
        {
            if (giveAmmo != null)
                giveAmmo();

            
            gunScript.reserveAmmo += ammoToGive;
            gunScript.CanReaload = true;
            Destroy(gameObject);
            return;
        }
    }
}
