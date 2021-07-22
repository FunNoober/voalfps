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
        if(WaveSpawnerInfinity.spawner != null) { WaveSpawnerInfinity.spawner.onKilled += Die; }
        if (CapedWaveSpawner.instance != null) CapedWaveSpawner.instance.onKilled += Die;
        if (CapedWaveSpawner.instance != null) CapedWaveSpawner.instance.currentEnemiesAlive++;
    }

    private void Update()
    {
        if(currentHealth <= 0) { Die(); }
    }

    public void Die()
    {
        if(WaveSpawnerInfinity.spawner != null) { WaveSpawnerInfinity.spawner.currentEnemiesAlive--; }
        if (CapedWaveSpawner.instance != null) CapedWaveSpawner.instance.currentEnemiesAlive--;
        Destroy(this.gameObject);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }    
}
