using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public Transform[] spawners;
    public GameObject objectToSpawn;
    public float spawnDelay;
    public int enemiesSpawned;
    public int enemiesInTheWave;
    public bool canSpawnEnemy;
    public bool canCountDown;
    public bool waveHasSpawned;
    public bool completeWaveSpawned;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        foreach(Transform pos in spawners)
        {
            Gizmos.DrawSphere(pos.position, .1f);
        }
    }

    private void Update()
    {
        if (enemiesSpawned > enemiesInTheWave)
            canSpawnEnemy = false;
        if(enemiesSpawned <= 0)
            canSpawnEnemy = true;        
        if (canSpawnEnemy)
            StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(spawnDelay);
        while(enemiesSpawned <= enemiesInTheWave)
        {
            foreach(Transform spawnPos in spawners)
            {
                Instantiate(objectToSpawn, spawnPos.position, Quaternion.identity);
                enemiesSpawned++;
            }
        }
    }
}
