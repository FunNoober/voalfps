using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L4AlienSpawn : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawners;
    public int currentWave;
    public GameObject enemy;
    public SceneFading fader;

    void Start()
    {
        foreach(Wave wave in waves)
        {
            if(GameObject.FindGameObjectsWithTag("Alien").Length <= 0)
            {
                foreach(Transform spawn in spawners)
                {
                    AlienManager manager = Instantiate(enemy, spawn.position, Quaternion.LookRotation(spawn.TransformDirection(Vector3.forward))).GetComponent<AlienManager>();
                    manager.playerInSight = true;
                }
            }
        }
    }

    
    void Update()
    {
        if(currentWave < waves.Length)
            StartCoroutine(checkEnemy());
        
        if(currentWave > waves.Length)
        {
            fader.hasStartedFade = true;
        }
    }

    public IEnumerator checkEnemy()
    {
        while(true)
        {
            foreach (Wave wave in waves)
            {
                if (GameObject.FindGameObjectsWithTag("Alien").Length <= 0)
                {
                    foreach (Transform spawn in spawners)
                    {
                        AlienManager manager = Instantiate(enemy, spawn.position, Quaternion.LookRotation(spawn.TransformDirection(Vector3.forward))).GetComponent<AlienManager>();
                        manager.playerInSight = true;
                    }
                    currentWave++;
                }
            }
            yield return new WaitForSeconds(0.5f);
        }

    }
}

[System.Serializable]
public class Wave
{
    public int alienCount;

}
