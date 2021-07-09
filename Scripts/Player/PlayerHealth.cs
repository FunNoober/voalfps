using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startShield = 100;
    public int startHealth = 100;

    public static int currentShield = 100;
    public static int currentHealth = 100;

    public GameObject deathUI;

    private bool shieldActive = true;
    private bool isDead;

    private void Awake()
    {
        currentShield = startShield;
        currentHealth = startHealth;
        shieldActive = true;
        deathUI.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(currentShield <= 0) { shieldActive = false; }
        if(currentHealth <= 0 && isDead == false) { Die(); }
    }

    public void TakeDamage(int amount)
    {
        if (shieldActive == true)
            currentShield -= amount;
        if (shieldActive == false)
            currentHealth -= amount;
    }

    public void Die()
    {
        isDead = true;
        deathUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
