using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShieldPickUp : MonoBehaviour
{
    public enum PickUpType
    {
        Shield,
        Health
    };

    private void Awake()
    {
        LeanTween.moveLocalY(gameObject, transform.position.y + 0.5f, 1f).setEaseInCubic().setEaseOutCubic().setLoopPingPong();
    }

    public PickUpType pickUp;

    public int returnValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                if (pickUp == PickUpType.Health)
                {
                    returnValue = (int)(PlayerHealth.currentHealth * 0.75f);

                    PlayerHealth.currentHealth += returnValue;
                    Destroy(this.gameObject);
                    return;

                }
                if (pickUp == PickUpType.Shield)
                {
                    returnValue = (int)(PlayerHealth.currentShield * 0.95f);

                    PlayerHealth.currentShield += returnValue;
                    Destroy(this.gameObject);
                    return;

                }
            }
        }
    }
}
