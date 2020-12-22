using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileHealth : MonoBehaviour
{
    public float health = 50f;

    public bool inSurvival;

    public WaveSystem waveSystemManager;

    void Start()
    {
        if (inSurvival)
        {
            waveSystemManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveSystem>();
            waveSystemManager.enemiesSpawned++;
        }
        if (waveSystemManager != null)
            inSurvival = true;
        else
            inSurvival = false;
    }
    
    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }


    }
    public void Die()
    {
        if(inSurvival && waveSystemManager != null)
            waveSystemManager.enemiesSpawned--;
        Destroy(gameObject);
    }
}
