using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform fpsCam;

    private void Start()
    {
        fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        transform.LookAt(fpsCam.position);
        transform.rotation *= Quaternion.Euler(0, 180, 0);
    }
}
