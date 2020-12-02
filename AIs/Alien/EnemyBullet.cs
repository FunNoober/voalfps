using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Collider player;

    public PlayerHealhAndShield healthShield;

    public float timeTillDestroy;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Collider>();
        healthShield = GameObject.FindWithTag("Player").GetComponent<PlayerHealhAndShield>();
    }

    void Update()
    {
        timeTillDestroy -= Time.deltaTime;
        if(timeTillDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter()
    {
        if(player.gameObject.tag == "Player")
        {
            healthShield.isTakingDamage = true;
            if(healthShield.ShieldActive && healthShield.isTakingDamage)
            {
               healthShield.TakeShield();
            }
            if(healthShield.ShieldActive == false && healthShield.isTakingDamage == true)
            {
                healthShield.TakeDamage();
            }
            healthShield.isTakingDamage = false;

        }
        
    }
}
