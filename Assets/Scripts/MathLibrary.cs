using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace groupRun
{
    public class MathLibrary : MonoBehaviour
    {
        public static void Multiplication(int operatorNum, List<GameObject> subPlayers, Transform artihmeticPos, List<GameObject> SpawnEffects)
        {
            int multiplyLoop = GameManager.characterCount * (operatorNum - 1);
            int number = 0;
            foreach (var i in subPlayers)
            {
                if (number < multiplyLoop)
                {
                    if (!i.activeInHierarchy)
                    {
                        foreach (var i2 in SpawnEffects)
                        {
                            if (!i2.activeInHierarchy)
                            {
                                i2.SetActive(true);
                                i2.transform.position = artihmeticPos.transform.position;
                                i2.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }
                        i.transform.position = artihmeticPos.position;
                        i.SetActive(true);
                        number++;
                    }
                }
                else
                {
                    number = 0;
                    break;
                }
            }

            GameManager.characterCount *= operatorNum;
        }

        public static void Addition(int operatorNum, List<GameObject> subPlayers, Transform artihmeticPos, List<GameObject> SpawnEffects)
        {
            int number2 = 0;
            foreach (var i in subPlayers)
            {
                if (number2 < operatorNum)
                {
                    if (!i.activeInHierarchy)
                    {
                        foreach (var i2 in SpawnEffects)
                        {
                            if (!i2.activeInHierarchy)
                            {
                                i2.SetActive(true);
                                i2.transform.position = artihmeticPos.transform.position;
                                i2.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }
                        i.transform.position = artihmeticPos.position;
                        i.SetActive(true);
                        number2++;
                    }
                }
                else
                {
                    number2 = 0;
                    break;
                }
            }

            GameManager.characterCount += operatorNum;
        }

        public static void Subtraction(int operatorNum, List<GameObject> subPlayers, List<GameObject> DespawnEffects)
        {
            if (GameManager.characterCount < operatorNum)
            {
                foreach (var i in subPlayers)
                {
                    foreach (var i2 in DespawnEffects)
                    {
                        if (!i2.activeInHierarchy)
                        {
                            i2.SetActive(true);
                            i2.transform.position = i.transform.position;
                            i2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }
                    i.transform.position = Vector3.zero;
                    i.SetActive(false);
                }

                GameManager.characterCount = 1;
            }
            else
            {
                int number3 = 0;
                foreach (var i in subPlayers)
                {
                    if (number3 != operatorNum)
                    {
                        if (i.activeInHierarchy)
                        {
                            foreach (var i2 in DespawnEffects)
                            {
                                if (!i2.activeInHierarchy)
                                {
                                    i2.SetActive(true);
                                    i2.transform.position = i.transform.position;
                                    i2.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }
                            i.transform.position = Vector3.zero;
                            i.SetActive(false);
                            number3++;
                        }
                    }
                    else
                    {
                        number3 = 0;
                        break;
                    }
                }

                GameManager.characterCount -= operatorNum;
            }
        }

        public static void Division(int operatorNum, List<GameObject> subPlayers, List<GameObject> DespawnEffects)
        {
            if (GameManager.characterCount <= operatorNum)
            {
                foreach (var i in subPlayers)
                {
                    foreach (var i2 in DespawnEffects)
                    {
                        if (!i2.activeInHierarchy)
                        {
                            i2.SetActive(true);
                            i2.transform.position = i.transform.position;
                            i2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }
                    i.transform.position = Vector3.zero;
                    i.SetActive(false);
                }

                GameManager.characterCount = 1;
            }
            else
            {
                var denominator = GameManager.characterCount - GameManager.characterCount / operatorNum;
                var number4 = 0;
                foreach (var i in subPlayers)
                {
                    if (number4 < denominator)
                    {
                        if (i.activeInHierarchy)
                        {
                            foreach (var i2 in DespawnEffects)
                            {
                                if (!i2.activeInHierarchy)
                                {
                                    i2.SetActive(true);
                                    i2.transform.position = i.transform.position;
                                    i2.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }
                            i.transform.position = Vector3.zero;
                            i.SetActive(false);
                            number4++;
                        }
                    }
                    else
                    {
                        number4 = 0;
                        break;
                    }
                }

                if (GameManager.characterCount % operatorNum == 0)
                {
                    GameManager.characterCount /= operatorNum;
                }
                else if (GameManager.characterCount % operatorNum == 1)
                {
                    GameManager.characterCount /= operatorNum;
                    GameManager.characterCount++;
                }
                else if (GameManager.characterCount % operatorNum == 2)
                {
                    GameManager.characterCount /= operatorNum;
                    GameManager.characterCount += 2;
                }
            }
        }
    }
}