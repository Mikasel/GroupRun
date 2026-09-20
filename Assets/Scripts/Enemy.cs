using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject Target;
    public NavMeshAgent agent;
    public Animator animator;
    public GameManager gameManager;
    private bool isAttackStart;
    void Start()
    {
        
    }

    public void TriggerAnimation()
    {
        animator.SetBool("Attack",  true);
        isAttackStart = true;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (isAttackStart)
        {
            agent.SetDestination(Target.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("subPlayer")) return;
        gameManager.DespawnPlayer(transform,false,true);

        gameObject.SetActive(false);   
    } 
}
