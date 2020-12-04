using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForEnemie : MonoBehaviour
{
    public WaveSystemLevel2[] waves;

    void OnTriggerEnter()
    {
        foreach(WaveSystemLevel2 theWave in waves)
        {
            theWave.canSpawn = true;
        }
    }
}
