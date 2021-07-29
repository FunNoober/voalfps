using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class BaseWaveSpawner : MonoBehaviour, IWaveSpawner
{
    public WaveSpawnerData data;

    public event Action onKilled;
    public event Action onSpawn;

    public Transform[] spawnPoints;

    public float timeBetweenWaves;

    protected float currentTimeBetweenWaves;

    public void Spawn()
    {
        currentTimeBetweenWaves = timeBetweenWaves;
        foreach (Transform point in spawnPoints)
        {
            Instantiate(data.enemyToSpawn, point.position, point.rotation);
        }
        InvokeOnSpawn();
    }

    public void SubtractWaveTime()
    {
        currentTimeBetweenWaves -= Time.deltaTime;
    }

    public void InvokeOnSpawn()
    {
        if (onSpawn != null) onSpawn();
    }

    public void InvokeOnDead()
    {
        if (onKilled != null) onKilled();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.black;
        Handles.Label(transform.position, "Wave Spawer " + transform.position.ToString(), style);

        Gizmos.DrawSphere(transform.position, 0.1f);

        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoints != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(spawnPoint.position, 2f);
            }
        }
    }
#endif
}
