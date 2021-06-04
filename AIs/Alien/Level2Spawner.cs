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
    public GameObject exitDoor;

    public int enemiesSpawned;
    public SceneFading fader;

    private void Update()
    {
        if (wave > maxWaves)
            canSpawn = false;
        if (wave < maxWaves)
            canSpawn = true;

        if (canSpawn)
            SpawnWave();

        if (wave >= maxWaves && enemiesSpawned <= 0)
            exitDoor.GetComponent<Animator>().SetBool("OpenDoor", true);

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
