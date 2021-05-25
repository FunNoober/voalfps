using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealhAndShield : MonoBehaviour
{
    public float health = 100;
    public float shield = 100;
    public bool shieldActive;

    public GameObject gameOverScreen;

    public Slider healthBar;
    public Slider shieldBar;

    public bool useCustomValues = false;

    [HideInInspector]
    public Slider[] slidersFound;

    private void Awake()
    {
        slidersFound = FindObjectsOfType<Slider>();
        foreach(Slider slider in slidersFound)
        {
            if (slider.gameObject.name == "ShieldBar")
                shieldBar = slider;
            if (slider.gameObject.name == "HealthBar")
                healthBar = slider;
        }
    }


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (useCustomValues == false)
        {
            health = 100f;
            shield = 100f;
        }
        shieldActive = true;
    }

    private void Update()
    {
        if(healthBar != null)
            health = Mathf.Clamp(health, 0f, 100f);

        if(shieldBar != null)
            shield = Mathf.Clamp(shield, 0f, 100f);

        shieldBar.value = shield;
        healthBar.value = health;


        if (shield <= 0)
            shieldActive = false;
        if (health <= 0)
            Die();
    }

    public void TakeDamage(float amount)
    {
        if (shieldActive)
            shield -= amount;
        else
            health -= amount;
    }

    public void Die()
    {
        gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        
        Time.timeScale = 0f;

    }

    public void ResartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
