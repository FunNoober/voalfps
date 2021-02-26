using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public bool aliensKilled;
    public int aliensAlive;
    public bool weaponPickedUp;
    public bool[] ammoPicked;
    public bool spawnedSecondWave;
    public SceneFading fader;

    AlienHealth[] alienHealths;
    public GameObject alienPrefab;

    public AmmoPickSet[] ammoPickUps;
    public Transform[] spawnPoints;


    private void Awake()
    {
        alienHealths = FindObjectsOfType<AlienHealth>();
        //ammoPickUps = FindObjectsOfType<AmmoPickSet>();
        foreach (AlienHealth health in alienHealths)
        {
            health.OnSpawn += AddAliens;

            health.OnDeath += SubtractAliens;
        }
        if (ammoPickUps[1].gameObject.name == "PistolAmmo2")
            ammoPickUps[1].giveAmmo += AddAmmoCountN2;
        if (ammoPickUps[0].gameObject.name == "PistolAmmo")
            ammoPickUps[0].giveAmmo += AddAmmoCount;

        aliensKilled = false;
    }

    private void Update()
    {

        if (aliensAlive == 0)
            aliensKilled = true;

        if (aliensKilled && weaponPickedUp && aliensAlive <= 0 && ammoPicked[0] == true && ammoPicked[1] == true)
        {
            if (!spawnedSecondWave)
            {
                foreach (Transform spawnLoc in spawnPoints)
                {
                    AlienHealth enemy = Instantiate(alienPrefab, spawnLoc.position, Quaternion.identity).GetComponent<AlienHealth>();
                    AlienManager ae = enemy.GetComponent<AlienManager>();
                    ae.playerInSight = true;
                    enemy.OnSpawn += AddAliens;
                    enemy.OnDeath += SubtractAliens;
                }
                spawnedSecondWave = true;
            }
            if (spawnedSecondWave && aliensKilled && weaponPickedUp && ammoPicked[0] == true && ammoPicked[1] == true)
                fader.FadeIn();
        }
    }

    public void SubtractAliens()
    {
        aliensAlive -= 1;
    }

    public void AddAliens()
    {
        aliensAlive++;
    }

    void AddAmmoCount()
    {
        if (ammoPickUps[1].id == 1)
        {
            ammoPicked[1] = true;
        }


    }

    void AddAmmoCountN2()
    {
        if (ammoPickUps[0].id == 0)
        {
            ammoPicked[0] = true;
        }
    }

}
