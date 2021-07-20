using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAI : MonoBehaviour
{
    public WaypointManager manager;
    public float moveSpeed;

    private int currentWaypoint;

    private void Update()
    {
        MoveNextWaypoint();
    }

    private void MoveNextWaypoint()
    {
        if(Vector3.Distance(transform.position, manager.points[currentWaypoint].position) <= 0.2f)
        {
            if(currentWaypoint >= manager.points.Length - 1)
            {
                currentWaypoint = 0;
            }
            currentWaypoint++;
        }
        transform.position = Vector3.MoveTowards(transform.position, manager.points[currentWaypoint].position, Time.deltaTime * moveSpeed);
        transform.LookAt(manager.points[currentWaypoint]);
    }
}
