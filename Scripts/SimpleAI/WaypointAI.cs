using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAI : MonoBehaviour
{
    public Transform[] waypointsPaths;
    int i;

    private void Awake()
    {
        transform.position = waypointsPaths[0].position;
        StartCoroutine(followPath());
    }

    IEnumerator followPath()
    {
        i = 1;
        Vector3 targetToFollow = waypointsPaths[i].position;

        while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetToFollow, Time.deltaTime * 16);
            if(transform.position == targetToFollow)
            {
                i = (i + 1) % waypointsPaths.Length;
                targetToFollow = waypointsPaths[i].position;
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
            transform.LookAt(targetToFollow);
            
        }
    }

    
}
