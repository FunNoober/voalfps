using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImpactDustScript : MonoBehaviour
{
    public Vector3 StartScale;

    void Start()
    {
        transform.localScale = StartScale;
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
