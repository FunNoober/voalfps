using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlienHealth : MonoBehaviour
{
    public float health = 50f;

    public bool inSurvival;

    public WaveSystem waveSystemManager;

    public Level2Spawner spawner;
    public bool inLevel2;

    public int enemyNumber;

    public event System.Action OnDeath;

    private Animator animator;
    private NavMeshAgent agent;
    private AlienManager manager;

    public event System.Action OnSpawn;

    private void Awake()
    {
        waveSystemManager = FindObjectOfType<WaveSystem>();
        spawner = FindObjectOfType<Level2Spawner>();

        if (waveSystemManager == null)
            inSurvival = false;
        else
            waveSystemManager.enemiesSpawned++;

        if (spawner == null)
            inLevel2 = false;
        else
            spawner.enemiesSpawned++;




        Spawned();


    }

    private void Start()
    {
        Spawned();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        manager = GetComponent<AlienManager>();
    }

    public void Spawned()
    {
        if (OnSpawn != null)
            OnSpawn();
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            StartCoroutine(Die());
        }


    }
    public IEnumerator Die()
    {
        if(OnDeath != null)
        {
            OnDeath();
        }
        
        if (inSurvival && waveSystemManager != null)
            waveSystemManager.enemiesSpawned--;
        if (inLevel2 && spawner != null)
            spawner.enemiesSpawned--;

        transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
        animator.SetTrigger("isDie");
        agent.enabled = false;
        manager.enabled = false;
        Debug.Log("Dead");
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
