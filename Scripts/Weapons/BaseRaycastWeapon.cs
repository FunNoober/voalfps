using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using com.funNoober.packages.cameraShake;
using funNoober.voal2.packages.bob;


public class BaseRaycastWeapon : MonoBehaviour
{
    [Header("Base Setup")]
    public BaseWeaponStats stats;
    public int reserveAmmo; //The Ammo Remaining Currently not In The Mag;
    public int currentAmmo; //The Ammo Reamaining in The Mag;
    public int weaponId;

    public Transform rayCastPoint; //The point the raycast is sent from;
    public Transform[] rayCastPoints; //Only Use if Shotgun
    public GameObject muzzleFlash; //The thing that shows when a gun is fired; Change this to particle for different results;
    public Animation animator;

    public Text ammoText;

    public StarndardActions actions;

    private bool isRealoading = false;
    private float nextTimeToFire;
    private bool canShoot;

    private void Awake() //Weapon Setup
    {
        actions = new StarndardActions();

        canShoot = true;
        reserveAmmo = stats.maxReserve;
        currentAmmo = stats.magSize;
        muzzleFlash.SetActive(false);
        isRealoading = false;

        animator = GetComponent<Animation>();

        DevConsole.giveAmmoAction += GiveMaxAmmo;
    }

    private void OnEnable()
    {
        if(WeaponManager.current != null)
            WeaponManager.current.currentIndex = weaponId;
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void Update()
    {
        if (PlayerMovement.isRunning) { transform.localPosition += new Vector3(0, BobSin.Bob(stats.runBobSpeed, stats.bobWhileRunning, stats.bobWhileRunning), 0); }
        else { transform.localPosition += new Vector3(0, BobSin.Bob(stats.baseBobSpeed, stats.baseBob, stats.baseBob), 0); }


        ammoText.text = currentAmmo.ToString() + "/" + reserveAmmo.ToString();
        if (isRealoading) { return; }
        if (currentAmmo <= 0 || actions.StarndardInput.Reload.ReadValue<float>() == 1 && currentAmmo < stats.magSize) { StartCoroutine(Reaload()); return; }
        if (reserveAmmo <= 0 && currentAmmo <= 0) { canShoot = !canShoot; }

        if (actions.StarndardInput.Shoot.ReadValue<float>() == 1 && Time.time >= nextTimeToFire && currentAmmo > 0 && canShoot)
        {
            nextTimeToFire = Time.time + 1f / stats.fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        CameraShake.Shake(0.1f, Camera.main);
        muzzleFlash.SetActive(true);
        StartCoroutine(DisableMuzzleFlash());
        currentAmmo--;

        if (animator != null && stats.shootClip != null) { animator.clip = stats.shootClip; animator.Play(); }


        if (stats.type == BaseWeaponStats.WeaponType.OneBullet)
        {
            RaycastHit hit;
            if (Physics.Raycast(rayCastPoint.position, rayCastPoint.transform.forward, out hit, stats.range, stats.shootMask))
            {
                EnemyHealth health = hit.transform.gameObject.GetComponent<EnemyHealth>();
                if (health != null)
                    health.TakeDamage(stats.damage);
            }
        }

        if (stats.type == BaseWeaponStats.WeaponType.Spread)
        {
            foreach (Transform rayPoint in rayCastPoints)
            {
                RaycastHit hit;
                rayPoint.rotation = Quaternion.Euler(randomVector3(stats.spead));
                if (Physics.Raycast(rayPoint.position, rayPoint.transform.forward, out hit, stats.range, stats.shootMask))
                {
                    EnemyHealth health = hit.transform.gameObject.GetComponent<EnemyHealth>();
                    if (health != null) { health.TakeDamage(stats.damage); }
                        
                }
            }
        }
        CameraShake.Reset(Camera.main);

    }

    public void GiveMaxAmmo()
    {
        reserveAmmo = 999;
        currentAmmo = 999;
    }

    public IEnumerator Reaload()
    {
        isRealoading = true;

        if (animator != null && stats.reloadClip != null) { animator.clip = stats.reloadClip; animator.Play(); }

        yield return new WaitForSeconds(stats.reloadTime);
        if (reserveAmmo >= stats.magSize)
            reserveAmmo -= stats.magSize;
        if (reserveAmmo > 0)
            currentAmmo = stats.magSize;
        isRealoading = false;
    }

    public IEnumerator DisableMuzzleFlash()
    {
        yield return new WaitForSeconds(0.29f);
        muzzleFlash.SetActive(false);
    }

    public Vector3 randomVector3(float randomAmout)
    {
        return new Vector3(Random.Range(-randomAmout, randomAmout), Random.Range(-randomAmout, randomAmout), Random.Range(-randomAmout, randomAmout));
    }
}
