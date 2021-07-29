using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneWave : MonoBehaviour
{

    public UnityEvent oneWaveComplete;

    public int enemiesAlive;

    public static OneWave instance;

    private bool waveHasCompleted;

    private void Awake()
    {
        GetInstance();
    }

    private void GetInstance()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        else
            Destroy(this);
    }

    private void Update()
    {
        if(enemiesAlive <= 0 && waveHasCompleted == false)
        {
            oneWaveComplete?.Invoke();
            waveHasCompleted = true;
        }
    }
}
