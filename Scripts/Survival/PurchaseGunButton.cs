using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseGunButton : MonoBehaviour
{
    public Text costText;
    public Text weaponToBuyText;
    public string weaponToPurchaseName;
    public float cost;
    public SurvivalManager manager;
    public Transform weaponToBuy;
    public Transform weaponStorage;
    public GunPewPewScript[] gunsInScene;

    public int weaponPurchaseIndex;
    public GunsAreActive gunManager;

    private void Awake()
    {
        gunsInScene = FindObjectsOfType<GunPewPewScript>();
    }

    private void Update()
    {
        costText.text = cost.ToString();
        weaponToBuyText.text = weaponToPurchaseName;
    }

    public void PurchaseWeapon()
    {
        FindWeapons();
        
        
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SurvivalManager>();
        if(manager.score >= cost)
        {
            weaponToBuy.SetParent(weaponStorage);
            manager.score -= (int)cost;
            foreach(GunPewPewScript gun in gunsInScene)
            {
                if (gun.gameObject.name != weaponToPurchaseName)
                    gun.gameObject.SetActive(false);
            }
            weaponToBuy.gameObject.SetActive(true);
            gunManager.weaponsAreActive[weaponPurchaseIndex] = true;
            Destroy(this.gameObject);
        }
    }

    public void FindWeapons()
    {
        gunsInScene = FindObjectsOfType<GunPewPewScript>();
    }
}
