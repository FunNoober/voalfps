using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForEnemie : MonoBehaviour
{
    public Level2Spawner spawnerSystem;

    void OnTriggerEnter()
    {
        spawnerSystem.canSpawn = true;
    }
}
