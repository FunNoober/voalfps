using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAI : MonoBehaviour
{
    public WaypointManager manager;
    public float moveSpeed;
    public bool loopOnComplete = false;

    private int currentWaypoint;

    private void Update()
    {
        MoveNextWaypoint();
    }

    private void MoveNextWaypoint()
    {
        if (Vector3.Distance(transform.position, manager.points[currentWaypoint].position) <= 0.2f)
        {
            if (currentWaypoint >= manager.points.Length - 1 && loopOnComplete)
            {
                currentWaypoint = 0;
            }
            if(!loopOnComplete)
            {
                transform.position = manager.points[0].position;
                currentWaypoint = 0;
            }
            currentWaypoint++;
        }
        transform.position = Vector3.MoveTowards(transform.position, manager.points[currentWaypoint].position, Time.deltaTime * moveSpeed);
        transform.LookAt(manager.points[currentWaypoint]);
    }
}
