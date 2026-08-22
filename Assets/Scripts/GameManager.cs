using System.Collections.Generic;
using UnityEngine;
using groupRun;

public class GameManager : MonoBehaviour
{
    public GameObject TargetPoint;
    public static int characterCount = 1;
    public List<GameObject> subPlayers;
    public List<GameObject> SpawnEffects;
    public List<GameObject> DespawnEffects;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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

    public void DespawnPlayer(Transform position)
    {
        foreach (var item in DespawnEffects)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = position.position;
                item.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}