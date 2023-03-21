using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] Animator animator;
    public Transform player;
    private Vector3 startPosition;
    public int seeDistanse;
    public float attackDistance;
    public HpSystem hpSystemPlayer;



    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", navAgent.speed);

        if (Vector3.Distance(transform.position, player.position) <= seeDistanse)
        {
                navAgent.destination = player.transform.position;


                if (Vector3.Distance(transform.position, player.position) <= attackDistance)
                {
                    animator.SetBool("isShooting", true);
                }
                else
                {
                    animator.SetBool("isShooting", false);
                }

        }
        else
        {
            navAgent.destination = startPosition;
        }
    }
}
