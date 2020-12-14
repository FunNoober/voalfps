using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseGunButton : MonoBehaviour
{
    public Text costText;
    public Text weaponToBuyText;
    public enum weaponName {Uzi, SAW, M4A1, Magnum,};
    public weaponName theGun;
    public float cost;
    public SurvivalManager manager;
    public Transform weaponToBuy;
    public Transform weaponStorage;
    public GameObject[] weaponsInScene; //The Guns That The Script Will Disable Besides The Gun That Is Getting Buyed

    private void Update()
    {
        costText.text = cost.ToString();
        weaponToBuyText.text = theGun.ToString();
    }

    public void PurchaseWeapon()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SurvivalManager>();
        if(manager.score >= cost)
        {
            weaponToBuy.SetParent(weaponStorage);
            manager.score -= (int)cost;
            foreach(GameObject gun in weaponsInScene)
            {
                gun.SetActive(false);
            }
            weaponToBuy.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
