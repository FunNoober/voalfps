using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileHealth : MonoBehaviour
{
    public float health = 50f;

    WaveSystem waveSystemManager;
    
    void Start()
    {
        waveSystemManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveSystem>();
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
        waveSystemManager.enemiesSpawned--;
        Destroy(gameObject);
    }
}
