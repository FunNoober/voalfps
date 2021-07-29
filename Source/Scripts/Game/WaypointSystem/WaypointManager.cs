using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public Transform[] points;

    private void OnDrawGizmos()
    {
        if(points != null)
        {
            foreach(Transform point in points)
            {
                Gizmos.DrawSphere(point.position, 0.2f);
                Gizmos.DrawWireSphere(point.position, 0.8f);
            }
        }
    }
}
