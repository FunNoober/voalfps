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

 public GunPewPewScript gunScript;

 public Collider Hero;

 public GunsAreActive theGunManager;

 public bool inSurvival;
 public int ScoreToBuy;
 public SurvivalManager manager;


 //All Weapons
public GameObject[] weapons;

 void OnTriggerEnter()
 {
    if(!inSurvival)
      SetParent();
 }

   public void SetParent()
   {
      if(Hero.gameObject.tag == "Player")
      {
         gunScript = WeaponPlayer.GetComponent<GunPewPewScript>();
         WeaponPlayer.transform.parent = Player.transform;
         WeaponPlayer.SetActive(true);
         theGunManager.weaponsAreActive[theWeaponIndex] = true;
         //Disable All Weapons
         foreach (GameObject weapon in weapons)
         {
            weapon.SetActive(false);
         }

         Destroy(gameObject);

      }
   }
 
}
