using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalManager : MonoBehaviour
{
    public bool nextWaveReady;
    public int hostilesInScene;

    void Update()
    {
        if(hostilesInScene <= 0)
        {
            nextWaveReady = true;
        }
    }
}
