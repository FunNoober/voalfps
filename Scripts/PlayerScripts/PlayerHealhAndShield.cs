using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealhAndShield : MonoBehaviour
{
    public bool ShieldActive = true;
    public bool isTakingDamage = false;
    public bool isdead;

    public int PlayerHealth = 100;
    public int PlayerShield = 100;
    public int damageToTake = 5;

    public GameObject DeathScreen;
    public GameObject RestartButton;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(ShieldActive && isTakingDamage)
        {
            TakeShield();
        }

        if(PlayerShield <= 0)
        {
            ShieldActive = false;
            PlayerShield = Mathf.Clamp(PlayerShield, 0, 100);
        }

        if(!ShieldActive && isTakingDamage)
        {
            TakeDamage();
        }

        if(!ShieldActive && PlayerHealth <= 0)
        {
            Death();
        }
    }

    void FixedUpdate()
    {

    }

    public void TakeDamage()
    {
        PlayerHealth -= damageToTake;
    }

    public void TakeShield()
    {
        PlayerShield -= damageToTake;
    }

    public void Death()
    {
        isdead = true;
        Cursor.lockState = CursorLockMode.None;
        RestartButton.SetActive(true);
        DeathScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
