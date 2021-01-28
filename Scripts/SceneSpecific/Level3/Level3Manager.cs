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
    public SceneFading fader;

    AlienHealth[] alienHealths;

    public AmmoPickSet[] ammoPickUps;
    

    private void Awake()
    {
        alienHealths = FindObjectsOfType<AlienHealth>();
        //ammoPickUps = FindObjectsOfType<AmmoPickSet>();
        foreach(AlienHealth health in alienHealths)
        {
            health.OnSpawn += AddAliens;
            
            health.OnDeath += SubtractAliens;
        }
        if (ammoPickUps[0].gameObject.name == "PistolAmmo2")
            ammoPickUps[0].giveAmmo += AddAmmoCount;
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
        if (ammoPickUps[0].id == 1)
        {
            ammoPicked[0] = true;
            
        }

    }
    
}
