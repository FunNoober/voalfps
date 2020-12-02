using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public PlayerHealhAndShield playerHealth;

    public Collider player;

    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealhAndShield>();
        player = GameObject.FindWithTag("Player").GetComponent<Collider>();
    }

    void OnTriggerEnter()
    {
    if(player.tag == "Player")
    {
        playerHealth.Death();
    }
    }
}
