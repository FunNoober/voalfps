using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public BaseEnemyData stats;

    public Transform rayCastPoint;
    public Transform shootPoint;

    private Transform player;

    private bool playerInRaduis;
    private bool playerInSight;
    private bool playerInAttack;

    private float nextTimeToFire;

    private NavMeshAgent agent;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= stats.attackRadius) { playerInAttack = true; }
        if (Vector3.Distance(transform.position, player.position) > stats.attackRadius) { playerInAttack = false; }

        if (!playerInRaduis && !playerInAttack)
        {
            Collider[] collidersInRaduis = Physics.OverlapSphere(transform.position, stats.detectionRadius, stats.playerMask);
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
            if (Physics.Raycast(rayCastPoint.position, rayCastPoint.forward, out RaycastHit hit, stats.detectionRadius, stats.detectionMask))
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

        if (playerInAttack) { agent.SetDestination(transform.position); }

        if (playerInAttack && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / stats.fireRate;
            Attack();       
        }
    }

    public void Attack()
    {
        Rigidbody projectileRb = Instantiate(stats.projectile, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>();
        projectileRb.transform.forward = shootPoint.forward;
        projectileRb.AddForce(shootPoint.forward * 45, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, stats.detectionRadius);
    }

}
