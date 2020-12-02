using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileHealth : MonoBehaviour
{
    public float health = 50f;

    public SurvivalManager mainManager;
    
    void Start()
    {
        mainManager = GameObject.FindWithTag("GameController").GetComponent<SurvivalManager>();
    }
    
    public void TakeDamage (float amount)
    {
    health -= amount;
    if (health <= 0f)
    {
        Die();
    }


}
    public void Die()
    {
      mainManager.hostilesInScene--;
      Destroy(gameObject);
    }
}
