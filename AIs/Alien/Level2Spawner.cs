using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Spawner : MonoBehaviour
{
    public int maxWaves;
    public int wave;
    public bool canSpawn;
    public Transform[] spawnPos;
    public GameObject enemy;

    private void Update()
    {
        if (wave > maxWaves)
            canSpawn = false;
        if (wave < maxWaves)
            canSpawn = true;
        
        if(canSpawn)
            SpawnWave();
    }

    void SpawnWave()
    {
        foreach(Transform pos in spawnPos)
        {
            Instantiate(enemy, pos.position, Quaternion.identity);
        }
        wave++;
    }
}
