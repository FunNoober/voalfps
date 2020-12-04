using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSystemLevel2 : MonoBehaviour
{
    public GameObject TheAlien;
    public int maxAliensToSpawn;
    public bool canSpawn;
    public bool HasSpawned;
    public float timeForWave;

    void Update()
    {
        if(maxAliensToSpawn <= 0)
            canSpawn = false;
        if(canSpawn)
            Spawn();
    }

    void Spawn()
    {
        if(!HasSpawned)
        {
            Instantiate(TheAlien, transform.position, transform.rotation);
            maxAliensToSpawn--;
            Invoke("HasSpawnedFalse", timeForWave);

        }
    }

    void HasSpawnedFalse()
    {
        HasSpawned = false;
    }
}
