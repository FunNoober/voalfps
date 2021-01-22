using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public bool aliensKilled;
    public int aliensAlive;
    public bool weaponPickedUp;
    public SceneFading fader;

    AlienHealth[] alienHealths;
    

    private void Awake()
    {
        alienHealths = FindObjectsOfType<AlienHealth>();
        foreach(AlienHealth health in alienHealths)
        {
            health.OnSpawn += AddAliens;
            
            health.OnDeath += SubtractAliens;
        }

        aliensKilled = false;
    }

    private void Update()
    {

        if (aliensAlive == 0)
            aliensKilled = true;
        
        if (aliensKilled && weaponPickedUp && aliensAlive <= 0)
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

    
}
