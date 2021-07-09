using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float detectionRadius;
    public float attackRaduis;
    public float fireRate;

    public LayerMask detectionMask;
    public LayerMask playerMask;

    public Transform rayCastPoint;

    private Transform player;

    [SerializeField]
    private bool playerInRaduis;
    [SerializeField]
    private bool playerInSight;
    [SerializeField]
    private bool playerInAttack;

    private NavMeshAgent agent;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRaduis) { playerInAttack = true; }
        if (Vector3.Distance(transform.position, player.position) > attackRaduis) { playerInAttack = false; }

        if (!playerInRaduis && !playerInAttack)
        {
            Collider[] collidersInRaduis = Physics.OverlapSphere(transform.position, detectionRadius, playerMask);
            foreach (Collider collider in collidersInRaduis)
            {
                if (collider.gameObject.CompareTag("Player"))
                {
                    playerInRaduis = true;
                }
            }
        }

        if (!playerInSight && !playerInAttack)
        {

            rayCastPoint.LookAt(player);
            if (Physics.Raycast(rayCastPoint.position, rayCastPoint.forward, out RaycastHit hit, detectionRadius, detectionMask))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    playerInSight = true;
                }
            }
        }

        if (playerInSight && playerInRaduis)
        {
            agent.SetDestination(player.position);
        }

        if (playerInAttack)
        {
            agent.SetDestination(transform.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.DrawLine(rayCastPoint.position, player.position);
    }

}
