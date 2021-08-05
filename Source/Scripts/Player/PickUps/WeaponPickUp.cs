using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Transform weaponToPickUp;
    public Transform weaponHolder;

    public bool useAnimations = true;

    private GameObject[] weaponsActive;

    private void Awake()
    {
        if (useAnimations == true)
            LeanTween.moveLocalY(gameObject, transform.position.y + 0.5f, 1f).setEaseInCubic().setEaseOutCubic().setLoopPingPong();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { PickUp(); }
    }

    private void PickUp()
    {
        weaponsActive = GameObject.FindGameObjectsWithTag("Gun");
        if (weaponsActive != null)
            foreach (GameObject weapon in weaponsActive)
            {
                if (weapon != null)
                    weapon.SetActive(false);
            }

        weaponToPickUp.parent = weaponHolder;
        weaponToPickUp.gameObject.SetActive(true);
        Destroy(this.gameObject);
        return;
    }
}
