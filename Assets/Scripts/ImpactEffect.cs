using System.Collections;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Passive());
    }
    IEnumerator Passive()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    
}
