using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAmmoSpawner : MonoBehaviour
{
    public Transform[] ammoSpawners;

    public Transform thePointToSpawn;

    public GameObject ammotype;

    public float countDownTimer;
    public float maxTimer;

    void Update()
    {
        countDownTimer -= Time.deltaTime;
        if(countDownTimer <= 0)
        {
            thePointToSpawn = ammoSpawners[Random.Range(0, ammoSpawners.Length)];
            Instantiate(ammotype, thePointToSpawn.position, thePointToSpawn.rotation);
            Debug.Log(thePointToSpawn.position);
            countDownTimer = maxTimer;

        }
    }
}
