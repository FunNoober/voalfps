using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startHealth;
    public int currentHealth;

    private void Awake()
    {
        currentHealth = startHealth;
        if(WaveSpawner.spawner != null) { WaveSpawner.onKilled += Die; }
    }

    private void Update()
    {
        if(currentHealth <= 0) { Die(); }
    }

    public void Die()
    {
        if(WaveSpawner.spawner != null) { WaveSpawner.spawner.currentEnemiesAlive--; }      
        Destroy(this.gameObject);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }    
}
