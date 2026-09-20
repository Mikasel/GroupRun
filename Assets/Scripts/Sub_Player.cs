using System;
using UnityEngine;
using UnityEngine.AI;

public class Sub_Player : MonoBehaviour
{
    NavMeshAgent _navMesh;
    public GameManager gameManager;
    public GameObject target;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _navMesh.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("spikeBox"))
        {
            GameManager.characterCount--;
            gameManager.DespawnPlayer(transform);
            gameObject.SetActive(false);
        }
        
        if (other.CompareTag("saw"))
        {
            GameManager.characterCount--;
            gameManager.DespawnPlayer(transform);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("fanSpike"))
        {
            GameManager.characterCount--;
            gameManager.DespawnPlayer(transform);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("hammer"))
        {
            gameManager.DespawnPlayer(transform, true);

            gameObject.SetActive(false);
        }
        if (other.CompareTag("enemy"))
        {
            gameManager.DespawnPlayer(transform,false,false);

            gameObject.SetActive(false);
        }
    }
}