using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AlienManager : MonoBehaviour
{
    public NavMeshAgent AI;

    public Transform player;
    public Vector3 traceOffest;

    public LayerMask whatPlayer;
    public LayerMask whatGround;

    public Vector3 walkPoint;
    public Transform shootPoint;
    public Transform[] raycastPoints;
    public bool walkPointSet;
    public float walkPointRange;

    public float delayBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange, visionRange;
    public bool playerInAttack, playerInSight;

    public Animator alienAnims;

    public GameObject projectile;

    public bool InSurvival = true;

    private Physics physics;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        AI = GetComponent<NavMeshAgent>();
        alienAnims = GetComponent<Animator>();
        physics = new Physics();
    }

    void Update()
    {
        foreach(Transform raycastPoint in raycastPoints)
        {
            RaycastHit[] coneHits = physics.ConeCastAll(transform.position, visionRange, transform.forward, visionRange, 25);
            if(coneHits.Length > 0)
            {
                foreach(RaycastHit hit in coneHits)
                {
                    if(hit.collider.CompareTag("Player"))
                    {
                        playerInSight = true;
                    }
                }
            }
        }




        playerInAttack = Physics.CheckSphere(transform.position, attackRange, whatPlayer);

        if (!playerInSight && !playerInAttack) Patroling();
        if (playerInSight && !playerInAttack) ChasePlayer();
        if (playerInAttack && playerInSight) Attacking();
    }

    void Patroling()
    {
        if(!walkPointSet) SearchWalkPoint();
        alienAnims.SetBool("IsAttacking", false);
        alienAnims.SetBool("isWalking", false);

        if(walkPointSet)
            AI.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    void Attacking()
    {
        AI.SetDestination(transform.position);

        transform.LookAt(player.position);
        alienAnims.SetBool("isWalking", false);

        if(!alreadyAttacked)
        {
            alienAnims.SetBool("IsAttacking", true);
            Rigidbody rb = Instantiate(projectile, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 16f);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), delayBetweenAttacks);
        }
    }

    void ChasePlayer()
    {
        AI.SetDestination(player.position);
        alienAnims.SetBool("IsAttacking", false);
        alienAnims.SetBool("isWalking", true);
        Debug.Log("In Pursuit");
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint, - transform.up, 2f, whatGround))
            walkPointSet = true;
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    void SetAttack()
    {
        alienAnims.SetBool("IsAttacking", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * visionRange);
    }
}
