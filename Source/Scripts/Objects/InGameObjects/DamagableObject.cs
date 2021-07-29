using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableObject : MonoBehaviour, IDamage
{

    public void TakeDamage()
    {
        Destroy(this.gameObject);
    }
}
