using System.Collections;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public Animator animator;
    public float waitTime;
    public BoxCollider wind;

    public void AnimationState(string state)
    {
        if (state == "true")
        {
            animator.SetBool("Start", true);
            wind.enabled = true;
        }
        else
        {
            animator.SetBool("Start", false);
            StartCoroutine(AnimationTrigger()); 
            wind.enabled = false;
        }
    }

    IEnumerator AnimationTrigger()
    {
        yield return new WaitForSeconds(waitTime);  
        AnimationState("true");
    }
}
