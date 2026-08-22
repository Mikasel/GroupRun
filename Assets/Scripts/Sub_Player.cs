using System;
using UnityEngine;
using UnityEngine.AI;

public class Sub_Player : MonoBehaviour
{
    GameObject target;

    NavMeshAgent _navMesh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().TargetPoint;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _navMesh.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "spikeBox")
        {
            GameManager.characterCount--;
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DespawnPlayer(transform);
            gameObject.SetActive(false);
        }
    }
}