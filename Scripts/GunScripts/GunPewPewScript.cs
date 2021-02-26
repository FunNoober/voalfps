using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class GunPewPewScript : MonoBehaviour
{
    #region Varibles
    [Header("Floats")]
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 10f;
    public float realoadTime = 25f;
    public float realoadWait = 0f;
    [Tooltip("The Mags The Player Has")] public float reserveAmmo;
    [Tooltip("The Reserve Ammo On Start")] public float customStartAmmo;
    [Tooltip("How Much The Reserve Ammo Is Being Multiplied")] public float customMultiplyAmmo;
    public float varibleAmmo;
    public float pickupAmmo;
    public float fireDelay;
    [Range(3, 15)]
    public float speedModifier = 8;
    [Range(4, 17)]
    public float runModifier = 11;

    public float[] RandomPickUpAmmo;
    public float ShotGunBange;

    [Space]
    [Header("Ints")]
    public int maxAmmo = 10;
    public int currentAmmo;
    public int ammoInMag; //The ammo in the mag when picked up
    public int generateRandom;
    public int randomRange1;
    public int randomRange2;
    public int shotsFired;

    [Space]
    [Header("Strings")]
    public string realoadingText;
    public string weaponType;
    public string textToDisplay;
    public string reloadBool;
    public string shootTrigger;

    [Space]
    [Header("GameObjects")]
    public GameObject impactEffect;
    public GameObject muzzelLight;
    public GameObject bulletMark;
    public GameObject enemyImpactEffect;

    public TextMeshProUGUI[] textFound;


    public PlayerMovement movementController;

    public AudioClip weaponShootingSFX;
    public AudioClip weaponSelectSFX;

    [Header("Bools")]
    public bool CanReaload = true;
    public bool isShotgun;

    [Tooltip("Checking If The Gun Is Full On Start")] public bool FullMagOnStart = true;
    public bool isActive;

    [Header("Text")]
    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI ammoText;

    public Camera fpsCam;

    public Animator animator;

    [Space]
    [Header("Color")]
    public Color realoadColor;
    public Color defaultColor;

    [Space]
    [Header("Vectors")]
    public Transform shotGunPoint;


    //Privates
    private float nextTimeToFire = 0f;
    private bool isReloading = false;

    public GunsAreActive weaponActive;
    public int currentWeaponIndex;



    #endregion

    #region One Time Call
    private void Awake()
    {
        AutoAssignVaribles();
    }

    public void AutoAssignVaribles()
    {
        animator = GetComponent<Animator>();
        movementController = FindObjectOfType<PlayerMovement>();
        realoadColor.a = 255;
        realoadColor.r = 82;
        realoadColor.g = 82;
        realoadColor.b = 82;
        defaultColor = Color.white;
        fpsCam = (Camera)FindObjectOfType(typeof(Camera));
        weaponActive = FindObjectOfType<GunsAreActive>();
        #region Cycling Through Text
        textFound = FindObjectsOfType<TextMeshProUGUI>();
        foreach (TextMeshProUGUI singleText in textFound)
        {
            if (singleText.gameObject.name == "AmmoText")
            {
                ammoText = singleText;
            }
        }
        foreach (TextMeshProUGUI singleText in textFound)
        {
            if (singleText.gameObject.name == "WeaponText")
            {
                weaponText = singleText;
            }
        }
        #endregion
    }

    void Start()
    {
        generateRandom = Random.Range(randomRange1, randomRange2);

        muzzelLight.SetActive(false);
        if (FullMagOnStart == false)
        {
            currentAmmo = (int)RandomPickUpAmmo[generateRandom];
        }
        else
        {
            currentAmmo = maxAmmo;
        }
        reserveAmmo = customStartAmmo;
        reserveAmmo *= customMultiplyAmmo;
        varibleAmmo = maxAmmo;
    }

    void OnEnable()
    {

        weaponActive.weaponsAreActive[currentWeaponIndex] = true;


        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "Muzzle")
                muzzelLight = child.gameObject;
        }


        isReloading = false;
        animator.SetBool(reloadBool, false);
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        source.clip = weaponSelectSFX;
    }
    #endregion

    void Update()
    {
        movementController.moveSpeed = speedModifier;
        movementController.runSpeed = runModifier;


        weaponText.text = textToDisplay;
        if (reserveAmmo <= -1)
        {
            CanReaload = false;
        }

        if (isReloading)
            return;


        if (CanReaload == true && currentAmmo < maxAmmo)
        {
            if (Input.GetKeyDown("r"))
            {
                StartCoroutine(Reaload());
                return;
            }

            if (currentAmmo <= 0)
            {
                StartCoroutine(Reaload());
                ammoText.text = realoadingText;
                return;
            }

        }

        if (currentAmmo > 0 && CanReaload == true)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();

            }
        }




        ammoText.text = currentAmmo.ToString() + ("/") + reserveAmmo.ToString();

        if (currentAmmo <= 2)
        {
            ammoText.color = realoadColor;
        }

        else
        {
            ammoText.color = defaultColor;
        }

        if (CanReaload == false)
        {
            currentAmmo = (int)0f;
            maxAmmo = (int)0f;
        }

        if (reserveAmmo <= 0 && CanReaload == false)
        {
            reserveAmmo = Mathf.Clamp(reserveAmmo, maxAmmo, 0);
        }

    }

    void Shoot()
    {
        muzzelLight.SetActive(true);
        AudioSource audio = GetComponent<AudioSource>();
        Invoke(nameof(LightOff), .05f);
        audio.Play();
        audio.clip = weaponShootingSFX;

        currentAmmo--;
        shotsFired++;
        animator.SetTrigger(shootTrigger);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range) && !isShotgun)
        {
            AlienHealth target = hit.transform.GetComponent<AlienHealth>();
            if (target != null)
            {
                
                target.TakeDamage(damage);
                GameObject enemyEffect = Instantiate(enemyImpactEffect, hit.point, Quaternion.identity);
                Destroy(enemyEffect, 5);
            }


            if (hit.collider.CompareTag("Enviroment"))
            {
                Vector3 upLocation = new Vector3(0, 0, 0);
                //+ Quaternion.AngleAxis(270, Vector3.right)
                GameObject bullectHole = Instantiate(bulletMark, hit.point, Quaternion.LookRotation(hit.normal) * Quaternion.AngleAxis(180, Vector3.right));
                Destroy(bullectHole, 20f);
            }
        }
        if (isShotgun)
        {
            Collider[] results = Physics.OverlapSphere(shotGunPoint.position, ShotGunBange);
            foreach (Collider theCollider in results)
            {

                AlienHealth enemyHealth = theCollider.GetComponent<AlienHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }

    #region Garbage
    public void LightOff()
    {
        muzzelLight.SetActive(false);
    }

    #endregion

    #region IEnumerators
    IEnumerator Reaload()
    {
        yield return new WaitForSeconds(realoadWait);
        isReloading = true;
        animator.SetBool(reloadBool, true);
        yield return new WaitForSeconds(realoadTime);
        animator.SetBool(reloadBool, false);
        shotsFired = 0;
        if (currentAmmo <= 0)
        {
            reserveAmmo += varibleAmmo;
            reserveAmmo -= maxAmmo;
        }
        else
        {
            reserveAmmo -= currentAmmo;
        }
        currentAmmo = maxAmmo;

        isReloading = false;
    }
    #endregion
}
