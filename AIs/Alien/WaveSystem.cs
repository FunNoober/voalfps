using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public float timeBetweenWaves;
    public float HostilesToCreate;
    public float standardTimeBetweenWaves = 10f;

    public Transform theSpawner;
    
    public GameObject Alien;

    public bool WaveHasSpawned = false;
    public bool waveCanSpawn;

    public SurvivalManager mainManager;

    void Start()
    {
        theSpawner = gameObject.GetComponent<Transform>();
        mainManager = GameObject.FindWithTag("GameController").GetComponent<SurvivalManager>();
    }

    void Update()
    {
        timeBetweenWaves -= Time.deltaTime;
        if(timeBetweenWaves <= 0 && mainManager.nextWaveReady == true  && waveCanSpawn == true)
        {
            Instantiate(Alien, theSpawner.position, theSpawner.rotation);
            timeBetweenWaves = standardTimeBetweenWaves;
        }
    }


}
