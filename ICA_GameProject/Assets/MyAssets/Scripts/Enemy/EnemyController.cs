using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//using tutorial: https://www.youtube.com/watch?v=UjkSFoLxesw
public class EnemyController : MonoBehaviour
{
    //variables
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    
    //on awake, find player and agent
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        //(position, radius, layermask)
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        
        //if to set the states
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    //patroling
    private void Patroling()
    {
        //if no walkpoint set, search for one
        if (!walkPointSet) SearchWalkPoint();

        //if walkpoint set, go to it
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        //get distance to walkpoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        //set walkpoint
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //check if walkpoint is on ground
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    //chase player
    private void ChasePlayer()
    {
        //set destination to player
        agent.SetDestination(player.position);
    }

    //attack player
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        //look at player
        transform.LookAt(player);

        //if not already attacking, attack
        if (!alreadyAttacked)
        {
            //creates projectile from prefab
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //add force to projectile
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);
            //set already attacked to true
            alreadyAttacked = true;
            //reset attack
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    //reset attack - set already attacked to false
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    
    //visualize sight and attack range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
