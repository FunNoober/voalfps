using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [Range(0, 100)]
    public float healthToGive = 25;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<PlayerHealhAndShield>().health <= 100)
            {
                other.GetComponent<PlayerHealhAndShield>().health += healthToGive;
                Destroy(this.gameObject);
            }
        }
    }
}
