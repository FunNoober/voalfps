using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileHealth : MonoBehaviour
{
    public float health = 50f;

    public event System.Action onDeath;

    public bool inSurvival = true;
    
    void Start()
    {

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
      if(onDeath != null)
        onDeath();
      Destroy(gameObject);
    }
}
