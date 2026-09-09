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
    public List<GameObject> ImpactEffects;


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

    public void DespawnPlayer(Transform position, bool hammer=false)
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
    }
}