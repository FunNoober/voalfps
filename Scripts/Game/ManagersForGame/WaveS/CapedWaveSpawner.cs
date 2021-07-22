using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CapedWaveSpawner : BaseWaveSpawner, IWaveSpawner
{
    public static CapedWaveSpawner instance;

    public UnityEvent onMaxWave;

    public int _maxWaves;
    public int currentEnemiesAlive;
    private int _currentWave;

    private bool hasOpened = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            return;
        }
    }

    private void Update()
    {
        SubtractWaveTime();
        if(currentTimeBetweenWaves <= 0 && _currentWave <= _maxWaves)
        {
            SpawnCaped();
        }
        if (_currentWave >= _maxWaves && currentEnemiesAlive == 0 && !hasOpened)
        {
            Debug.Log("Ready To Open");
            if (onMaxWave != null)
                onMaxWave.Invoke();
            hasOpened = true;
        }
    }

    public void SpawnCaped()
    {
        _currentWave++;
        Spawn();
    }
}
