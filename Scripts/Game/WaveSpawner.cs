using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner spawner;

    public WaveSpawnerData data;
    public int currentEnemiesAlive;
    public Transform[] spawnPoints;

    public event Action onKilled;

    private void Awake()
    {
        if (spawner == null) { spawner = this; return; }
            
        if (spawner != null) { Destroy(this.gameObject); return; }
            
    }

    public void Killed()
    {
        if (onKilled != null)
            onKilled();
    }

    private void Update()
    {
        if (currentEnemiesAlive <= 0)
            Spawn();
    }

    public void Spawn()
    {
        foreach(Transform spawnPoint in spawnPoints)
        {
            currentEnemiesAlive++;
            Instantiate(data.enemyToSpawn, spawnPoint.position, Quaternion.identity);            
        }
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
