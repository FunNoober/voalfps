using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public PlayerHealhAndShield HealthShield;

    public Collider MainPlayer;
    public Collider healthCrateCollider;

    public Renderer healthCrateRenderer;

    public GameObject WhiteFlash;
    public GameObject theHealthCrate;

    void Start()
    {
        HealthShield = GameObject.FindWithTag("Player").GetComponent<PlayerHealhAndShield>();
        MainPlayer = GameObject.FindWithTag("Player").GetComponent<Collider>();
        healthCrateCollider = theHealthCrate.GetComponent<Collider>();
        healthCrateRenderer = theHealthCrate.GetComponent<Renderer>();
    }

    void OnTriggerEnter()
    {
        StartCoroutine(GiveHealth());
    }

    IEnumerator GiveHealth()
    {
        if(HealthShield.PlayerHealth <= 99)
        {
            HealthShield.PlayerHealth  += 25;
            HealthShield.PlayerHealth = Mathf.Clamp(HealthShield.PlayerHealth, 0, 100);
            WhiteFlash.SetActive(true);
            healthCrateCollider.enabled = false;
            healthCrateRenderer.enabled = false;
            yield return new WaitForSeconds(2);
            WhiteFlash.SetActive(false);
        }
    }
}
