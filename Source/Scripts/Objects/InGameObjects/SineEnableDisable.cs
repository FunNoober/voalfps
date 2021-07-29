using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineEnableDisable : MonoBehaviour
{
    public GameObject objectToSetActive;
    public float speed;
    public float magnitude;

    private float sineAmount;

    void Update()
    {
        sineAmount = magnitude * Mathf.Sin(speed * Time.time);
        if (sineAmount <= 1)
            objectToSetActive.SetActive(true);
        if (sineAmount <= 0)
            objectToSetActive.SetActive(false);
            
    }
}
