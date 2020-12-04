using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunPewPewScript : MonoBehaviour
{
    //Publics
[Header("Floats")]
public float damage = 10f;
public float range = 100f;
public float fireRate = 10f;
public float realoadTime = 25f;
public float realoadWait = 0f;
[Tooltip("The Mags The Player Has")]public float reserveAmmo;
[Tooltip("The Reserve Ammo On Start")] public float customStartAmmo;
[Tooltip("How Much The Reserve Ammo Is Being Multiplied")] public float customMultiplyAmmo;
public float varibleAmmo;
public float pickupAmmo;
public float fireDelay;
[Range(5, 15)]
public float speedModifier;
[Range(6, 17)]
public float runModifier;

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
[Header("GameObjectss")]
public GameObject impactEffect;
public GameObject muzzelLight;
public GameObject bulletMark;

public PlayerMovement movementController;

public AudioClip weaponShootingSFX;
public AudioClip weaponSelectSFX;

[Header("Bools")]
public bool CanReaload = true;
public bool isShotgun;

[Tooltip("Checking If The Gun Is Full On Start")] public bool FullMagOnStart = true;
public bool isActive;

[Header("Text")]
public Text ammoText;
public Text weaponPickUpText;

public Camera fpsCam;

public Animator animator;

[Space]
[Header("Color")]
public Color newColor;
public Color defaultColor;

[Space]
[Header("Vectors")]
public Vector3 upRecoil;
[SerializeField] Vector3 origRotation;
public Transform shotGunPoint;


    //Privates
    private float nextTimeToFire = 0f;
    private bool isReloading = false;
      
    void Start()
    {
        generateRandom = Random.Range(randomRange1, randomRange2);
        fpsCam = (Camera)FindObjectOfType(typeof(Camera));
        
        muzzelLight.SetActive(false);
        if(FullMagOnStart == false)
        {
        currentAmmo = (int) RandomPickUpAmmo[generateRandom];
        }
        else
        {
        currentAmmo = maxAmmo;
        }
        reserveAmmo = customStartAmmo;
        reserveAmmo *= customMultiplyAmmo;
        varibleAmmo = maxAmmo;
        origRotation = transform.localEulerAngles;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool(reloadBool, false);
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        source.clip = weaponSelectSFX;
    }

    void Update()
    {
        movementController.moveSpeed = speedModifier;
        movementController.runSpeed = runModifier;

        
        weaponPickUpText.text = textToDisplay;
        if(reserveAmmo <= -1)
        {
CanReaload = false;
        }

        if (isReloading)
            return;

        if(Input.GetButtonUp("Fire1"))
            StopRecoil();

        
        
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

        if(currentAmmo <= 2)
        {
            ammoText.color = newColor;
        }

        else
        {
            ammoText.color = defaultColor;
        }

        if (CanReaload == false)
        {
          currentAmmo = (int) 0f;
          maxAmmo = (int) 0f;
        }

        if(reserveAmmo <= 0 && CanReaload == false)
        {
            reserveAmmo = Mathf.Clamp (reserveAmmo, maxAmmo, 0);
        }

    }

    void Shoot()
    {
        muzzelLight.SetActive(true);
        Invoke("lightOff", .02f);
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        audio.clip = weaponShootingSFX;
        AddRecoil();

        currentAmmo--;
        shotsFired++;
        animator.SetTrigger(shootTrigger);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range) && !isShotgun)
        {
            Debug.Log(hit.transform.name);

            HostileHealth target = hit.transform.GetComponent<HostileHealth>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

           //This adds 90's to the X Axis -->
           if(hit.collider.tag == "Enviroment")
            {
                GameObject bullectHole = Instantiate(bulletMark, hit.point, Quaternion.LookRotation(hit.normal) * Quaternion.AngleAxis(90, Vector3.right));
                Destroy(bullectHole, 20f);
            }

            if (hit.collider.tag == "Target")
            {
                GameObject bullectHole = Instantiate(bulletMark, hit.point, Quaternion.LookRotation(hit.normal) * Quaternion.AngleAxis(90, Vector3.right));
                Destroy(bullectHole, 20f);
            }
        }
        if(isShotgun)
        {
            Collider[] results = Physics.OverlapSphere(shotGunPoint.position, ShotGunBange);
            foreach(Collider theCollider in results)
            {
                
               HostileHealth enemyHealth = theCollider.GetComponent<HostileHealth>();
                if(enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }

    public void lightOff()
    {
        muzzelLight.SetActive(false);
    }

    void AddRecoil()
    {
        transform.localEulerAngles+=upRecoil;
    }

    void StopRecoil()
    {
        transform.localEulerAngles = origRotation;
    }

    IEnumerator Reaload()
    {
        yield return new WaitForSeconds(realoadWait);
        isReloading = true;
        Debug.Log("WAIT FOREVEVER");
        animator.SetBool(reloadBool, true);
        yield return new WaitForSeconds(realoadTime);
        animator.SetBool(reloadBool,false);
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

}
