using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    public int weaponId;
    public BaseRaycastWeapon weapon;

    public int ammoToReturn;

<<<<<<< Updated upstream
    private void Awake()
    {
        LeanTween.moveLocalY(gameObject, transform.position.y + 0.5f, 1f).setEaseInCubic().setEaseOutCubic().setLoopPingPong();
=======
    public bool usePickUpAnimations;

    private void Awake()
    {
        if(usePickUpAnimations == true)
            LeanTween.moveLocalY(gameObject, transform.position.y + 0.5f, 1f).setEaseInCubic().setEaseOutCubic().setLoopPingPong();
>>>>>>> Stashed changes
    }

    private void OnTriggerEnter(Collider other)
    {
        if(weaponId == WeaponManager.current.currentIndex && other.gameObject.CompareTag("Player"))
        {
            weapon.reserveAmmo += ammoToReturn;
            Destroy(this.gameObject);
            return;
        }
    }
}
