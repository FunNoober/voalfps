using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBarrier : MonoBehaviour
{
    public GameObject barrierToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            barrierToDisable.SetActive(false);
        }
    }
}
