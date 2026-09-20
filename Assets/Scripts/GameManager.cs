using System.Collections.Generic;
using UnityEngine;
using groupRun;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static int characterCount = 1;
    public List<GameObject> subPlayers;
    public List<GameObject> SpawnEffects;
    public List<GameObject> DespawnEffects;
    public List<GameObject> ImpactEffects;
   
    [Header("LEVEL DATA")]
    public List<GameObject> Enemy;
    [FormerlySerializedAs("IntendedEnemyCount")] public int EnemyCount;
    public GameObject Player;
    private bool _isGameOver;
    bool isLastTrigger;
    
    void Start()
    {
        CreateEnemy();
    }

    public void CreateEnemy()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            Enemy[i].SetActive(true);
        }
    }

    public void TriggerEnemy()
    {
        foreach (var item in Enemy)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Enemy>().TriggerAnimation();
            }
        } 
        isLastTrigger = true;
        ArenaState();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ArenaState()
    {
        if (isLastTrigger)
        {
            if (characterCount == 1 || EnemyCount == 0)
            {
                _isGameOver = true;
                foreach (var item in Enemy)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Attack",false);
                    }
                }
                foreach (var item in subPlayers)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Attack",false);
                    }
                }
                Player.GetComponent<Animator>().SetBool("Attack",false);
            
                if (characterCount <= EnemyCount )
                {
                    Debug.Log("You Lost!");
                }
                else
                {
                    Debug.Log("You Won!");
                }
            }
        }
        
    }
    public void SpawnPlayer(string operatorType, int operatorNum, Transform artihmeticPos)
    {
        switch (operatorType)
        {
            case "multiplication":
                MathLibrary.Multiplication(operatorNum, subPlayers, artihmeticPos, SpawnEffects);
                break;

            case "addition":
                MathLibrary.Addition(operatorNum, subPlayers, artihmeticPos, SpawnEffects);
                break;

            case "subtraction":
                MathLibrary.Subtraction(operatorNum, subPlayers, DespawnEffects);
                break;

            case "division":
                MathLibrary.Division(operatorNum, subPlayers, DespawnEffects);
                break;
        }
    }

    public void DespawnPlayer(Transform position, bool hammer=false, bool state=false)
    {
        foreach (var item in DespawnEffects)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = position.position;
                item.GetComponent<ParticleSystem>().Play();
                if (!state)
                    characterCount--;
                else
                    EnemyCount--;
                break;
            }
        }

        if (hammer)
        {
            Vector3 hammerPos = new Vector3(position.position.x, .03f, position.position.z);
            foreach (var item in ImpactEffects)
            {
                if (!item.activeInHierarchy)
                {
                    item.SetActive(true);
                    item.transform.position = hammerPos;
                    break;
                }
            }
        }

        if (!_isGameOver)
            ArenaState();
    }
}