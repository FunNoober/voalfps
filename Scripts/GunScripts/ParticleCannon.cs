//Fun Noober//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParticleCannon : MonoBehaviour
{
    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI ammoText;
    public Camera fpsCam;
    public float energy;
    public float maxEnergy;
    public float maxEnergyMultiplyer;
    public float damage;
    public ParticleSystem laser;
    public LayerMask interactibles;


    private void Start()
    {
        energy = maxEnergy *= maxEnergyMultiplyer;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && energy > 0)
            ShootLaser();
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.TransformDirection(Vector3.forward) * 64);
        weaponText.text = "Particle Cannon";
        ammoText.text = energy.ToString();
    }

    void ShootLaser()
    {
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.TransformDirection(Vector3.forward), out RaycastHit hit, interactibles))
        {
            laser.Play();
            AlienHealth enemyHealth = hit.collider.gameObject.GetComponent<AlienHealth>();
            if (enemyHealth != null)
                enemyHealth.TakeDamage(damage);
            Debug.Log(hit.collider.name);
        }
        energy--;
    }
}
