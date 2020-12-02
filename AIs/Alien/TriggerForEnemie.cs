using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForEnemie : MonoBehaviour
{
    public WaveSystem[] waves;

    public WaveSystem theWave;

    void OnTriggerEnter()
    {
        foreach(WaveSystem theWave in waves)
        {
            theWave.waveCanSpawn = true;
        }
    }
}
