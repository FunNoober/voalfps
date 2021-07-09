using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.funNoober.packages.cameraShake;

public class BaseRaycastWeapon : MonoBehaviour
{
    [Header("Base Setup")]
    public int maxReserveAmmo; //The reserve ammo on start;
    public int reserveAmmo; //The Ammo Remaining Currently not In The Mag;
    public int magSize; //The currentAmmo on start;
    public int currentAmmo; //The Ammo Reamaining in The Mag;
    public float fireRate; //How fast the gun can fire;
    public float range; //The Max Size of the Raycast;
    public float reloadTime; //The Time it takes to reload;
    public float damage;

    public Transform rayCastPoint; //The point the raycast is sent from;
    public GameObject muzzleFlash; //The thing that shows when a gun is fired; Change this to particle for different results;

    public Text ammoText;
    


    private bool isRealoading = false;
    private float nextTimeToFire;
    private bool canShoot;

    private void Awake() //Weapon Setup
    {
        canShoot = true;
        reserveAmmo = maxReserveAmmo;
        currentAmmo = magSize;
        muzzleFlash.SetActive(false);
        isRealoading = false;
        StartCoroutine(UpdateAmmoText());
    }

    private void Update()
    {
        if (isRealoading) { return; }
        if(currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R) && currentAmmo < magSize) { StartCoroutine(Reaload()); return; }
        if(reserveAmmo <= 0 && currentAmmo <= 0) { canShoot = !canShoot; }

        if(Input.GetMouseButton(0) && Time.time >= nextTimeToFire && currentAmmo > 0 && canShoot)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        CameraShake.Shake(0.1f, Camera.main);
        muzzleFlash.SetActive(true);
        StartCoroutine(DisableMuzzleFlash());
        currentAmmo--;

        if(Physics.Raycast(rayCastPoint.position, rayCastPoint.transform.forward, out hit, range))
        {
            IDamage damage = hit.transform.gameObject.GetComponent<IDamage>();
            if (damage != null)
                damage.TakeDamage();
        }
        CameraShake.Reset(Camera.main);

    }

    public IEnumerator Reaload()
    {
        isRealoading = true;
        yield return new WaitForSeconds(reloadTime);
        if(reserveAmmo >= magSize)
            reserveAmmo -= magSize;
        if(reserveAmmo > 0)
            currentAmmo = magSize;
        isRealoading = false;
    }

    public IEnumerator UpdateAmmoText()
    {
        while(true)
        {
            ammoText.text = currentAmmo.ToString() + "/" + reserveAmmo.ToString();
            yield return new WaitForSeconds(0.25f);
        }
    }
    
    public IEnumerator DisableMuzzleFlash()
    {
        yield return new WaitForSeconds(0.29f);
        muzzleFlash.SetActive(false);
    }
}
