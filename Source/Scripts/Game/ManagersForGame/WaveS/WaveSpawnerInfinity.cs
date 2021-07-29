using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaveSpawnerInfinity : BaseWaveSpawner, IWaveSpawner
{
    public static WaveSpawnerInfinity spawner;

    public int currentEnemiesAlive;

    private void Awake()
    {
        if (spawner == null) { spawner = this; return; }

        if (spawner != null) { Destroy(this.gameObject); return; }

    }

    private void Update()
    {
        if (currentEnemiesAlive <= 0)
        {
            SubtractWaveTime();
            if (currentTimeBetweenWaves <= 0)
                Spawn();
        }
    }

    public void SpawnInfinity()
    {
        Spawn();
    }
}
