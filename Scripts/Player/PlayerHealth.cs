using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*dependencies : deathUI, healthBar, shieldBar, DevConsole*/
public class PlayerHealth : MonoBehaviour
{
    public int startShield = 100;
    public int startHealth = 100;

    public static int currentShield = 100;
    public static int currentHealth = 100;

    public GameObject deathUI;

    public Slider healthBar;
    public Slider shieldBar;

    private bool shieldActive = true;
    private bool isDead;

    private bool hasInvulnerability;

    private void Awake()
    {
        currentShield = startShield;
        currentHealth = startHealth;
        shieldActive = true;
        deathUI.SetActive(false);
        Time.timeScale = 1;

        healthBar.value = currentHealth;
        shieldBar.value = currentShield;

        StartCoroutine(UpdateBars());

        DevConsole.giveHealthAction += EnableInvulnerability;
        DevConsole.takeHealthAction += DisableInvulnerability;
    }

    private void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        currentShield = Mathf.Clamp(currentShield, 0, 100);
    }

    private void FixedUpdate()
    {
        if (currentShield <= 0) { shieldActive = false; }
        if (currentHealth <= 0 && isDead == false) { Die(); }
    }

    public void TakeDamage(int amount)
    {
        if (hasInvulnerability == false)
        {
            if (shieldActive == true)
                currentShield -= amount;
            if (shieldActive == false)
                currentHealth -= amount;
        }
    }

    public void Die()
    {
        isDead = true;
        deathUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public IEnumerator UpdateBars()
    {
        while (true)
        {
            healthBar.value = currentHealth;
            shieldBar.value = currentShield;

            yield return new WaitForSeconds(0.5f);
        }
    }

    #region

    public void EnableInvulnerability()
    {
        hasInvulnerability = true;
    }

    public void DisableInvulnerability()
    {
        hasInvulnerability = false;
    }

    #endregion
}
