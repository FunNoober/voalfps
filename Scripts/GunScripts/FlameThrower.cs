using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class FlameThrower : MonoBehaviour
{
    [Space]
    [Header("Shooting")]
    public int flameLeft;
    public int maxFlame;
    public bool canFire;

    [Space]
    [Header("Flames")]
    public Transform point;
    public float flameSize;
    public GameObject GFX;
    public float GFXDuration;
    public float damage;

    [Space]
    [Header("SFX")]
    public AudioClip SFX;

    [Space]
    [Header("UI")]
    public Text AmmoText;
    public Text weaponText;

    void Start()
    {
        flameLeft = maxFlame;
        GFX.SetActive(false);
    }
    
    void Update()
    {
        AmmoText.text = flameLeft.ToString();
        weaponText.text = "Flame Thrower";
        if(flameLeft <= 0)
            canFire = false;
        if(Input.GetMouseButton(0) && canFire)
        {
            Fire();
        }
        if(Input.GetMouseButtonUp(0))
        {
            GFX.SetActive(false);
        }
    }

    void Fire()
    {
        GFX.SetActive(true);
        AudioSource source = GetComponent<AudioSource>();
        flameLeft--;
        source.Play();
        source.clip = SFX;

        Collider[] thingsToFire = Physics.OverlapSphere(point.position, flameSize);
        foreach(Collider objects in thingsToFire)
        {
            AlienHealth enemyHealth = objects.GetComponent<AlienHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }

}
