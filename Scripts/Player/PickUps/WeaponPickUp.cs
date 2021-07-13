using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Transform weaponToPickUp;
    public Transform weaponHolder;

    private GameObject[] weaponsActive;

    private void Awake()
    {
        LeanTween.moveLocalY(gameObject, transform.position.y + 0.5f, 1f).setEaseInCubic().setEaseOutCubic().setLoopPingPong();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { PickUp(); }
    }

    private void PickUp()
    {
        weaponsActive = GameObject.FindGameObjectsWithTag("Gun");
        foreach(GameObject weapon in weaponsActive) { weapon.SetActive(false); }

        weaponToPickUp.parent = weaponHolder;
        weaponToPickUp.gameObject.SetActive(true);
        Destroy(this.gameObject);
        return;
    }
}
