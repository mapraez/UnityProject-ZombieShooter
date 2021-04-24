using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] AudioClip zombieHit;
    [SerializeField] AudioClip zombieGrowl;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    bool isGrowling = false;
    EnemyHealth health;
    Transform target;
    AudioSource audioSource;
    CapsuleCollider capsuleCollider;
    Light spotLight;


    void Start()
    {
        // target = FindObjectOfType<PlayerHealth>().transform;
        target = GameObject.FindWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        audioSource = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        spotLight = GetComponentInChildren<Light>();
    }


    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
            capsuleCollider.enabled = false;
            spotLight.enabled = false;

        }
        else
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position);
            if (distanceToTarget > chaseRange)
            {
                isGrowling = false;
            }
            else
            {
                isProvoked = true;
                if (!isGrowling)
                {
                    StartCoroutine(Growl());
                }
            }
            if (isProvoked)
            {
                EngageTarget();
            }

        }
    }

    public void OnDamageTaken()
    {
        if (health.IsDead()) { return; }
        isProvoked = true;
        audioSource.PlayOneShot(zombieHit, 0.5f);
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            if (FindObjectOfType<PlayerHealth>().hitPoints <= 0)
            {
                GetComponent<Animator>().SetBool("Attack", false);
            }
            else
            {
                AttackTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        // transform.rotation = where target is, rotate ate certain speed
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    IEnumerator Growl()
    {
        audioSource.PlayOneShot(zombieGrowl, 0.5f);
        isGrowling = true;
        yield return new WaitForSeconds(3);
        isGrowling = false;
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }
}
