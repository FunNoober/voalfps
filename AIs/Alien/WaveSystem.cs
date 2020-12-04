using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public Wave[] waves;
    public Wave currentWave;
    int currentWaveNumber;
    public float StandardTimeBetweenWaves;
    public int EnemiesLeftTillSpawn;
    public int hostilesAlive;

    public GameObject enemy;

    public SurvivalManager manager;

    void Start()
    {
        NextWave();
    }
    
    void Update()
    {
        if(EnemiesLeftTillSpawn > 0 && Time.time > StandardTimeBetweenWaves)
        {
            EnemiesLeftTillSpawn--;
            StandardTimeBetweenWaves = Time.time + currentWave.nextSpawnTime;

            HostileHealth health = Instantiate(enemy, transform.position, Quaternion.identity).GetComponent<HostileHealth>();
            health.onDeath += OnEnemyDeath;
        }
    }

    void OnEnemyDeath()
    {
        print("Enemy Dead");
        hostilesAlive--;

        if(hostilesAlive <= 0)
        {
            NextWave();
        }

        manager.score += 100;
    }

    void NextWave()
    {
        currentWaveNumber++;
        if(currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];
            EnemiesLeftTillSpawn = currentWave.NumberofEnemies;
            hostilesAlive = EnemiesLeftTillSpawn;
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int NumberofEnemies;
        public float nextSpawnTime;
    }
}

