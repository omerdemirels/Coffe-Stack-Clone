using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleeveAnim : MonoBehaviour
{
 


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform.parent.GetChild(1).GetComponent<Animator>() != null)
            {
                Animator animator=transform.parent.GetChild(1).GetComponent<Animator>();
                animator.SetBool("OpenCup", true);
            }
        }
    }


}
